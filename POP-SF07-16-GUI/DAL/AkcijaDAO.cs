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
    public static class AkcijaDAO
    {
        public static ObservableCollection<Akcija> GetList()
        {
            var akcijaLista = new ObservableCollection<Akcija>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM akcija WHERE obrisan = 0; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "akcija"); // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["akcija"].Rows)
                {
                    var a = new Akcija();
                    a.Id = int.Parse(row["id"].ToString());
                    a.Naziv = row["naziv"].ToString();
                    a.DatumPocetka = DateTime.Parse(row["datumPocetka"].ToString());
                    a.DatumZavrsetka = DateTime.Parse(row["datumZavrsetka"].ToString());
                    a.Popust = decimal.Parse(row["popust"].ToString());
                    a.Obrisan = bool.Parse(row["obrisan"].ToString());
                    akcijaLista.Add(a);
                }
            }

            return akcijaLista;
        }

        public static Akcija GetById(int id)
        {
            Akcija akcija = null;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM akcija WHERE id = @id; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.Parameters.AddWithValue("id", id);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "akcija"); // izvrsava se query nad bazom

                // Bice samo jedan red vracen, naravno
                foreach (DataRow row in ds.Tables["akcija"].Rows)
                {
                    akcija = new Akcija();
                    akcija.Id = int.Parse(row["id"].ToString());
                    akcija.DatumPocetka = DateTime.Parse(row["datumPocetka"].ToString());
                    akcija.DatumZavrsetka = DateTime.Parse(row["datumZavrsetka"].ToString());
                    akcija.Naziv = row["naziv"].ToString();
                    akcija.Obrisan = bool.Parse(row["obrisan"].ToString());
                }
            }

            return akcija;
        }

        public static Akcija Add(Akcija a)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $" INSERT INTO akcija (naziv, datumPocetka, datumZavrsetka, popust) " +
                    $"VALUES (@naziv, @datumPocetka, @datumZavrsetka, @popust); ";
                cmd.CommandText += " SELECT SCOPE_IDENTITY(); "; // metoda koja uzima identity poslednjeg upisanog elementa

                cmd.Parameters.AddWithValue("naziv", a.Naziv);
                cmd.Parameters.AddWithValue("datumPocetka", a.DatumPocetka);
                cmd.Parameters.AddWithValue("datumZavrsetka", a.DatumZavrsetka);
                cmd.Parameters.AddWithValue("popust", a.Popust);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar izvrsava query nad bazom
                a.Id = newId;
            }
            Projekat.Instance.AkcijaLista.Add(a); // Azuriram i model!

            return a;
        }

        public static void Update(Akcija a)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " UPDATE akcija " +
                    "SET naziv = @naziv, datumPocetka = @datumPocetka, datumZavrsetka = @datumZavrsetka, popust = @popust, obrisan = @obrisan  " +
                    "WHERE id = @id; ";

                cmd.Parameters.AddWithValue("naziv", a.Naziv);
                cmd.Parameters.AddWithValue("datumPocetka", a.DatumPocetka);
                cmd.Parameters.AddWithValue("datumZavrsetka", a.DatumZavrsetka);
                cmd.Parameters.AddWithValue("popust", a.Popust);
                cmd.Parameters.AddWithValue("id", a.Id);
                cmd.Parameters.AddWithValue("obrisan", a.Obrisan);

                cmd.ExecuteNonQuery();

                // Azuriram model, listu u modelu
                // ISPRAVKA : Aj popravi imena tih varijabli, ne zna se ko koga ...
                foreach (Akcija it in Projekat.Instance.AkcijaLista)
                {
                    if (it.Id == a.Id)
                    {
                        it.Naziv = a.Naziv;
                        it.DatumPocetka = a.DatumPocetka;
                        it.DatumZavrsetka = a.DatumZavrsetka;
                        it.Popust = a.Popust;
                        it.Obrisan = a.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Akcija a)
        {
            a.Obrisan = true;
            Update(a);
        }




        /*
        public static void Add(Akcija akcija)
        {
            akcija.Id = GetList().Count;
            akcija.Obrisan = false;
            ObservableCollection<Akcija> lista = GetList();
            lista.Add(akcija);
            UpdateList(lista);
        }

        public static void Update(Akcija akcija)
        {
            ObservableCollection<Akcija> list = GetList();
            list[akcija.Id] = akcija;
            UpdateList(list);
        }

        public static ObservableCollection<Akcija> GetList()
        {
            return Projekat.Instance.AkcijaLista;
        }

        public static void UpdateList(ObservableCollection<Akcija> newList)
        {
            Projekat.Instance.AkcijaLista = newList;
        }

        public static Akcija GetById(int id)
        {
            Akcija akcija = null;
            foreach (Akcija a in GetList())
            {
                if (a.Id == id)
                {
                    akcija = a;
                    break;
                }
            }
            return akcija;
        }
        */
    }
}
