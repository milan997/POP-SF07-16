using POP_SF07_16.Model;
using POP_SF07_16_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POP_SF07_16_GUI.DAL
{
    public static class ProdajaDAO
    {
        public static ObservableCollection<Prodaja> GetList()
        {
            var prodajaLista = new ObservableCollection<Prodaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM prodaja; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "prodaja"); // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["prodaja"].Rows)
                {
                    var p = new Prodaja();

                    int id = int.Parse(row["id"].ToString());

                    p.Id = id;
                    p.DatumProdaje = DateTime.Parse(row["datumProdaje"].ToString());
                    p.BrRacuna = row["brRacuna"].ToString();
                    p.Kupac = row["kupac"].ToString();

                    p.KupljeniNamestajLista = CollectionKupljeniNamestajDAO.GetById(id);
                    p.KupljenaDodatnaUslugaLista = CollectionKupljenaDodatnaUslugaDAO.GetById(id);

                    foreach (KupljeniNamestaj kn in p.KupljeniNamestajLista)
                        kn.Prodaja = p;

                    foreach (KupljenaDodatnaUsluga kdu in p.KupljenaDodatnaUslugaLista)
                        kdu.Prodaja = p;

                    prodajaLista.Add(p);
                }
            }

            return prodajaLista;
        }

        public static Prodaja GetById(int id)
        {
            Prodaja prodaja = null;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM prodaja WHERE id = @id; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.Parameters.AddWithValue("id", id);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "prodaja"); // izvrsava se query nad bazom

                // Bice samo jedan red vracen, naravno
                foreach (DataRow row in ds.Tables["prodaja"].Rows)
                {
                    prodaja = new Prodaja();

                    id = int.Parse(row["id"].ToString());
                    prodaja.Id = id;
                    prodaja.DatumProdaje = DateTime.Parse(row["datumProdaje"].ToString());
                    prodaja.BrRacuna = row["brRacuna"].ToString();
                    prodaja.Kupac = row["kupac"].ToString();

                    prodaja.KupljeniNamestajLista = CollectionKupljeniNamestajDAO.GetById(id);
                    foreach (KupljeniNamestaj kn in prodaja.KupljeniNamestajLista)
                        kn.Prodaja = prodaja;

                    prodaja.KupljenaDodatnaUslugaLista = CollectionKupljenaDodatnaUslugaDAO.GetById(id);
                    foreach (KupljenaDodatnaUsluga kdu in prodaja.KupljenaDodatnaUslugaLista)
                        kdu.Prodaja = prodaja;
                }
            }

            return prodaja;
        }

       
        public static Prodaja Add(Prodaja p)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Pisanje primitivnih parametara
                    SqlCommand cmd = new SqlCommand(" INSERT INTO prodaja (datumProdaje, brRacuna, kupac) " +
                        "VALUES (@datumProdaje, @brRacuna, @kupac); SELECT SCOPE_IDENTITY(); ", con, transaction);
                    cmd.Parameters.AddWithValue("datumProdaje", p.DatumProdaje);
                    cmd.Parameters.AddWithValue("brRacuna", p.BrRacuna);
                    cmd.Parameters.AddWithValue("kupac", p.Kupac);

                    int newId = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar izvrsava query nad bazom
                    p.Id = newId;

                    // Pisanje kupljenog namestaja
                    foreach (KupljeniNamestaj kn in p.KupljeniNamestajLista)
                    {
                        cmd = new SqlCommand(" INSERT INTO collection_kupljeniNamestaj (prodaja_id, namestaj_id, kolicina, obrisan) " +
                        "VALUES (@prodaja_id, @namestaj_id, @kolicina, @obrisan); ", con, transaction);
                        cmd.Parameters.AddWithValue("prodaja_id", kn.Prodaja.Id);
                        cmd.Parameters.AddWithValue("namestaj_id", kn.Namestaj.Id);
                        cmd.Parameters.AddWithValue("kolicina", kn.Kolicina);
                        cmd.Parameters.AddWithValue("obrisan", kn.Obrisan);
                        cmd.ExecuteNonQuery();
                    }

                    // Pisanje kupljenih dodatnih usluga
                    foreach (KupljenaDodatnaUsluga kdu in p.KupljenaDodatnaUslugaLista)
                    {
                        cmd = new SqlCommand(" INSERT INTO collection_kupljenaDodatnaUsluga (prodaja_id, dodatnaUsluga_id, kolicina, obrisan) " +
                        "VALUES (@prodaja_id, @dodatnaUsluga_id, @kolicina, @obrisan); ", con, transaction);
                        cmd.Parameters.AddWithValue("prodaja_id", kdu.Prodaja.Id);
                        cmd.Parameters.AddWithValue("dodatnaUsluga_id", kdu.DodatnaUsluga.Id);
                        cmd.Parameters.AddWithValue("kolicina", kdu.Kolicina);
                        cmd.Parameters.AddWithValue("obrisan", kdu.Obrisan);
                        cmd.ExecuteNonQuery();
                    }


                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    MessageBoxResult mbr = MessageBox.Show("Nije uspeo upis u bazu! Transakcija ponistena!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            Projekat.Instance.ProdajaLista.Add(p); // Azuriram i model!

            return p;
        }

        public static void Update(Prodaja p)
        {
            //BAZA
            
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlTransaction transaction = con.BeginTransaction();
                try
                {

                    // Update primitivnih parametara
                    SqlCommand cmd = new SqlCommand(" UPDATE prodaja " +
                    " SET datumProdaje = @datumProdaje, brRacuna = @brRacuna, kupac = @kupac " +
                    " WHERE id = @id; ", con, transaction);
                    cmd.Parameters.AddWithValue("datumProdaje", p.DatumProdaje);
                    cmd.Parameters.AddWithValue("brRacuna", p.BrRacuna);
                    cmd.Parameters.AddWithValue("kupac", p.Kupac);
                    cmd.Parameters.AddWithValue("id", p.Id);
                    cmd.ExecuteNonQuery();

                    // Brisanje kupljenih namestaja
                    cmd = new SqlCommand(" DELETE FROM collection_kupljeniNamestaj " +
                        " WHERE prodaja_id = @id; ", con, transaction);
                    cmd.Parameters.AddWithValue("id", p.Id);
                    cmd.ExecuteNonQuery();

                    // Dodavanje novih kupljenih namestaja
                    foreach(KupljeniNamestaj kn in p.KupljeniNamestajLista)
                    {
                        cmd = new SqlCommand( " INSERT INTO collection_kupljeniNamestaj (prodaja_id, namestaj_id, kolicina, obrisan) " +
                        "VALUES (@prodaja_id, @namestaj_id, @kolicina, @obrisan); ", con, transaction);
                        cmd.Parameters.AddWithValue("prodaja_id", kn.Prodaja.Id);
                        cmd.Parameters.AddWithValue("namestaj_id", kn.Namestaj.Id);
                        cmd.Parameters.AddWithValue("kolicina", kn.Kolicina);
                        cmd.Parameters.AddWithValue("obrisan", kn.Obrisan);
                        cmd.ExecuteNonQuery();
                    }

                    // Brisanje kupljenih dodatnih usluga
                    cmd = new SqlCommand(" DELETE FROM collection_kupljenaDodatnaUsluga " +
                        " WHERE prodaja_id = @id; ", con, transaction);
                    cmd.Parameters.AddWithValue("id", p.Id);
                    cmd.ExecuteNonQuery();

                    // Dodavanje novih kupljenih namestaja
                    foreach (KupljenaDodatnaUsluga kdu in p.KupljenaDodatnaUslugaLista)
                    {
                        cmd = new SqlCommand(" INSERT INTO collection_kupljenaDodatnaUsluga (prodaja_id, dodatnaUsluga_id, kolicina, obrisan) " +
                        "VALUES (@prodaja_id, @dodatnaUsluga_id, @kolicina, @obrisan); ", con, transaction);
                        cmd.Parameters.AddWithValue("prodaja_id", kdu.Prodaja.Id);
                        cmd.Parameters.AddWithValue("dodatnaUsluga_id", kdu.DodatnaUsluga.Id);
                        cmd.Parameters.AddWithValue("kolicina", kdu.Kolicina);
                        cmd.Parameters.AddWithValue("obrisan", kdu.Obrisan);
                        cmd.ExecuteNonQuery();
                    }

                    // Commit
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    MessageBoxResult mbr = MessageBox.Show("Nije uspeo upis u bazu! Transakcija ponistena!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            // MODEL

            // Azuriram model, listu u modelu
            // ISPRAVKA : Aj popravi imena tih varijabli, ne zna se ko koga ...
            foreach (Prodaja it in Projekat.Instance.ProdajaLista)
            {
                if (it.Id == p.Id)
                {
                    it.DatumProdaje = p.DatumProdaje;
                    it.BrRacuna = p.BrRacuna;
                    it.Kupac = p.Kupac;
                    it.KupljenaDodatnaUslugaLista = p.KupljenaDodatnaUslugaLista;
                    it.KupljeniNamestajLista = p.KupljeniNamestajLista;
                    break;
                }
            }
        }

        public static Prodaja GetFromSingleton(int id)
        {
            foreach (Prodaja p in Projekat.Instance.ProdajaLista)
            {
                if (p.Id == id)
                    return p;
            }

            return null;
        }

    }
}
