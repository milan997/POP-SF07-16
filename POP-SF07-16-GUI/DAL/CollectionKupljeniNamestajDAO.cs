using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class CollectionKupljeniNamestajDAO
    {
        /*
        public static ObservableCollection<KupljeniNamestaj> GetList()
        {
            var kupljeniNamestajLista = new ObservableCollection<KupljeniNamestaj>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM collection_kupljeniNamestaj WHERE obrisan = 0; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "collection_kupljeniNamestaj"); // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["collection_kupljeniNamestaj"].Rows)
                {
                    var a = new KupljeniNamestaj();
                    a.Id = int.Parse(row["id"].ToString());
                    a.Naziv = row["naziv"].ToString();
                    a.DatumPocetka = DateTime.Parse(row["datumPocetka"].ToString());
                    a.DatumZavrsetka = DateTime.Parse(row["datumZavrsetka"].ToString());
                    a.Popust = decimal.Parse(row["popust"].ToString());
                    a.Obrisan = bool.Parse(row["obrisan"].ToString());
                    kupljeniNamestajLista.Add(a);
                }
            }

            return kupljeniNamestajLista;
        }
        */

        
        public static ObservableCollection<KupljeniNamestaj> GetById(int id)
        {
            /*
             * Funkcija vraca sve kupljene namestaje vezane za prodaju
             * Prosledjujemo joj ID prodaje ciji kupljene namestaje zelimo
             * Vraca ObservableCollection kupljenihNamestaja
            */
            var kupljeniNamestajLista = new ObservableCollection<KupljeniNamestaj>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM collection_kupljeniNamestaj WHERE prodaja_id = @id AND obrisan = 0; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.Parameters.AddWithValue("id", id);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "collection_kupljeniNamestaj"); // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["collection_kupljeniNamestaj"].Rows)
                {
                    var kn = new KupljeniNamestaj();
                    //kn.Prodaja = ProdajaDAO.GetFromSingleton(int.Parse(row["prodaja_id"].ToString()));
                    kn.Namestaj = NamestajDAO.GetById(int.Parse(row["namestaj_id"].ToString()));
                    kn.Kolicina = int.Parse(row["kolicina"].ToString());
                    kupljeniNamestajLista.Add(kn);
                }
            }

            return kupljeniNamestajLista;
        }
        

        public static void Add(KupljeniNamestaj kn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $" INSERT INTO collection_kupljeniNamestaj (prodaja_id, namestaj_id, kolicina) " +
                    $"VALUES (@prodaja_id, @namestaj_id, @kolicina); ";
                cmd.CommandText += " SELECT SCOPE_IDENTITY(); "; // metoda koja uzima identity poslednjeg upisanog elementa

                cmd.Parameters.AddWithValue("prodaja_id", kn.Prodaja.Id);
                cmd.Parameters.AddWithValue("namestaj_id", kn.Namestaj.Id);
                cmd.Parameters.AddWithValue("kolicina", kn.Kolicina);

                cmd.ExecuteScalar().ToString(); // ExecuteScalar izvrsava query nad bazom
                
            }
            var prodajaLista = Projekat.Instance.ProdajaLista; // Azuriram i model!

            /*
            foreach (Prodaja p in prodajaLista)
            {
                if (p.Id == kn.Prodaja.Id)
                {
                    p.KupljeniNamestajLista.Add(kn);
                    break;
                }
            }
            */
        }

        public static void Update(KupljeniNamestaj kn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " UPDATE collection_kupljeniNamestaj " +
                    " SET prodaja_id = @prodaja_id, namestaj_id = @namestaj_id, kolicina = @kolicina, obrisan = @obrisan  " +
                    " WHERE  prodaja_id = @prodaja_id AND namestaj_id = @namestaj_id; ";

                cmd.Parameters.AddWithValue("prodaja_id", kn.Prodaja.Id);
                cmd.Parameters.AddWithValue("namestaj_id", kn.Namestaj.Id);
                cmd.Parameters.AddWithValue("kolicina", kn.Kolicina);
                cmd.Parameters.AddWithValue("obrisan", kn.Obrisan);

                cmd.ExecuteNonQuery();

                // Azuriram model, listu u modelu
                // ISPRAVKA : Aj popravi imena tih varijabli, ne zna se ko koga ...
                /*
                foreach (Prodaja it in Projekat.Instance.ProdajaLista)
                {
                    if(it.Id == kn.Prodaja.Id)
                    {
                        foreach(KupljeniNamestaj it2 in it.KupljeniNamestajLista)
                        {
                            if(it2.Namestaj.Id == kn.Namestaj.Id)
                            {
                                it2.Namestaj = kn.Namestaj;
                                it2.Prodaja = kn.Prodaja;
                                it2.Kolicina = kn.Kolicina;
                                it2.Obrisan = kn.Obrisan;
                            }
                        }
                    }
                }
                */
            }
        }

        public static void Delete(KupljeniNamestaj kn)
        {
            kn.Obrisan = true;
            Update(kn);
        }

        public static void DeleteAll(int id)
        {
            // Funkcija koja brise sve kupljene namestaje vezane za prodaju iz baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " UPDATE collection_kupljeniNamestaj " +
                    " SET obrisan = 1  " +
                    " WHERE prodaja_id = @id; ";

                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
