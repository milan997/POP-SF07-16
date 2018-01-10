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

namespace POP_SF07_16_GUI.DAL
{
    public static class CollectionKupljenaDodatnaUslugaDAO
    {
        public static ObservableCollection<KupljenaDodatnaUsluga> GetById(int id)
        {
            /*
             * Funkcija vraca sve kupljene dodatne usluge vezane za prodaju
             * Prosledjujemo joj ID prodaje ciji kupljene dodatne usluge zelimo
             * Vraca ObservableCollection kupljenihDodatnihUsluga
            */
            var kupljenaDodatnaUslugaLista = new ObservableCollection<KupljenaDodatnaUsluga>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM collection_kupljenaDodatnaUsluga WHERE prodaja_id = @id AND obrisan = 0; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.Parameters.AddWithValue("id", id);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "collection_kupljenaDodatnaUsluga"); // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["collection_kupljenaDodatnaUsluga"].Rows)
                {
                    var kn = new KupljenaDodatnaUsluga();
                    //kn.Prodaja = ProdajaDAO.GetById(int.Parse(row["prodaja_id"].ToString()));
                    kn.DodatnaUsluga = DodatnaUslugaDAO.GetById(int.Parse(row["dodatnaUsluga_id"].ToString()));
                    kn.Kolicina = int.Parse(row["kolicina"].ToString());
                    kupljenaDodatnaUslugaLista.Add(kn);
                }
            }

            return kupljenaDodatnaUslugaLista;
        }


        public static void Add(KupljenaDodatnaUsluga kdu)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $" INSERT INTO collection_kupljenaDodatnaUsluga (prodaja_id, dodatnaUsluga_id, kolicina) " +
                    $"VALUES (@prodaja_id, @dodatnaUsluga_id, @kolicina); ";
                cmd.CommandText += " SELECT SCOPE_IDENTITY(); "; // metoda koja uzima identity poslednjeg upisanog elementa

                cmd.Parameters.AddWithValue("prodaja_id", kdu.Prodaja.Id);
                cmd.Parameters.AddWithValue("dodatnaUsluga_id", kdu.DodatnaUsluga.Id);
                cmd.Parameters.AddWithValue("kolicina", kdu.Kolicina);

                cmd.ExecuteScalar().ToString(); // ExecuteScalar izvrsava query nad bazom

            }


            var prodajaLista = Projekat.Instance.ProdajaLista; // Azuriram i model!
            /*
            foreach (Prodaja p in prodajaLista)
            {
                if (p.Id == kdu.Prodaja.Id)
                {
                    p.KupljenaDodatnaUslugaLista.Add(kdu);
                    break;
                }
            }
            */
        }

        public static void Update(KupljenaDodatnaUsluga kn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " UPDATE collection_kupljenaDodatnaUsluga " +
                    " SET prodaja_id = @prodaja_id, dodatnaUsluga_id = @dodatnaUsluga_id, kolicina = @kolicina, obrisan = @obrisan  " +
                    " WHERE  prodaja_id = @prodaja_id AND dodatnaUsluga_id = @dodatnaUsluga_id; ";

                cmd.Parameters.AddWithValue("prodaja_id", kn.Prodaja.Id);
                cmd.Parameters.AddWithValue("dodatnaUsluga_id", kn.DodatnaUsluga.Id);
                cmd.Parameters.AddWithValue("kolicina", kn.Kolicina);
                cmd.Parameters.AddWithValue("obrisan", kn.Obrisan);

                cmd.ExecuteNonQuery();

                // Azuriram model, listu u modelu
                // ISPRAVKA : Aj popravi imena tih varijabli, ne zna se ko koga ...
                /*
                foreach (Prodaja it in Projekat.Instance.ProdajaLista)
                {
                    if (it.Id == kn.Prodaja.Id)
                    {
                        foreach (KupljenaDodatnaUsluga it2 in it.KupljenaDodatnaUslugaLista)
                        {
                            if (it2.DodatnaUsluga.Id == kn.DodatnaUsluga.Id)
                            {
                                it2.DodatnaUsluga = kn.DodatnaUsluga;
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

        public static void Delete(KupljenaDodatnaUsluga kn)
        {
            kn.Obrisan = true;
            Update(kn);
        }

        public static void DeleteAll(int id)
        {
            // Funkcija koja brise sve kupljene dodatne usluge vezane za prodaju iz baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " UPDATE collection_kupljenaDodatnaUsluga " +
                    " SET obrisan = 1  " +
                    " WHERE prodaja_id = @id; ";

                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
