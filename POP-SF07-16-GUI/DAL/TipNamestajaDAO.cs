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
    public static class TipNamestajaDAO
    {
        public static ObservableCollection<TipNamestaja> GetList()
        {
            var tipNamestajaLista = new ObservableCollection<TipNamestaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM tipNamestaja WHERE obrisan = 0; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "tipNamestaja"); // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["tipNamestaja"].Rows)
                {
                    var tn = new TipNamestaja();
                    tn.Id = int.Parse(row["id"].ToString());
                    tn.Naziv = row["naziv"].ToString();
                    tn.Obrisan = bool.Parse(row["obrisan"].ToString());
                    tipNamestajaLista.Add(tn);
                }
            }

            return tipNamestajaLista;
        }

        public static TipNamestaja GetById(int id)
        {
            TipNamestaja tipNamestaja = null;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM tipNamestaja WHERE id = @id; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.Parameters.AddWithValue("id", id);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "tipNamestaja"); // izvrsava se query nad bazom

                // Bice samo jedan red vracen, naravno
                foreach (DataRow row in ds.Tables["tipNamestaja"].Rows)
                {
                    tipNamestaja = new TipNamestaja();
                    tipNamestaja.Id = int.Parse(row["id"].ToString());
                    tipNamestaja.Naziv = row["naziv"].ToString();
                    tipNamestaja.Obrisan = bool.Parse(row["obrisan"].ToString());
                }
            }

            return tipNamestaja;
        }

        public static TipNamestaja Add(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $" INSERT INTO tipNamestaja (naziv, obrisan) VALUES (@naziv, @obrisan); ";
                cmd.CommandText += " SELECT SCOPE_IDENTITY(); "; // metoda koja uzima identity poslednjeg upisanog elementa

                cmd.Parameters.AddWithValue("naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("obrisan", tn.Obrisan);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar izvrsava query nad bazom
                tn.Id = newId;
            }
            Projekat.Instance.TipNamestajaLista.Add(tn); // Azuriram i model!

            return tn;
        }

        public static void Update(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " UPDATE tipNamestaja " +
                    "SET naziv = @naziv, obrisan = @obrisan  " +
                    "WHERE id = @id; ";

                cmd.Parameters.AddWithValue("id", tn.Id);
                cmd.Parameters.AddWithValue("naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();

                // Azuriram model, listu u modelu
                // ISPRAVKA : Aj popravi imena tih varijabli, ne zna se ko koga ...
                foreach (TipNamestaja it in Projekat.Instance.TipNamestajaLista)
                {
                    if (it.Id == tn.Id)
                    {
                        it.Naziv = tn.Naziv;
                        it.Obrisan = tn.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(TipNamestaja tn)
        {
            tn.Obrisan = true;
            // Dodati metodu koja ce kad obrisemo Tip Namestaja obrisati i sve Namestaje tog tipa
            Update(tn);
        }


        /*
        public static void Add(TipNamestaja tipNamestaja)
        {
            tipNamestaja.Id = GetList().Count;
            tipNamestaja.Obrisan = false;
            ObservableCollection<TipNamestaja> list = GetList();
            list.Add(tipNamestaja);
            UpdateList(list);
        }

        public static void Update(TipNamestaja tipNamestaja)
        {
            ObservableCollection<TipNamestaja> list = GetList();
            list[tipNamestaja.Id] = tipNamestaja;
            UpdateList(list);
        }

        public static ObservableCollection<TipNamestaja> GetList()
        {
            return Projekat.Instance.TipNamestajaLista;
        }

        public static void UpdateList(ObservableCollection<TipNamestaja> newList)
        {
            Projekat.Instance.TipNamestajaLista= newList;
        }

        public static TipNamestaja GetById(int id)
        {
            TipNamestaja tipNamestaja = null;
            foreach (TipNamestaja tn in GetList()){
                if(tn.Id == id)
                {
                    tipNamestaja = tn;
                    break;
                }
            }
            return tipNamestaja;
        }
        */
    }
}