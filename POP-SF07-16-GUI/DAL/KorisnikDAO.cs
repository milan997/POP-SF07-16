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
    public static class KorisnikDAO
    {

        public static ObservableCollection<Korisnik> GetList()
        {
            var korisnikLista = new ObservableCollection<Korisnik>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM korisnik WHERE obrisan = 0; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "korisnik"); // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["korisnik"].Rows)
                {
                    var k = new Korisnik();
                    k.Id = int.Parse(row["id"].ToString());
                    k.Ime = row["ime"].ToString();
                    k.Prezime = row["prezime"].ToString();
                    k.KorIme = row["korIme"].ToString();
                    k.Lozinka = row["lozinka"].ToString();

                    bool tipKorisnika = bool.Parse(row["tipKorisnika"].ToString());
                    k.TipKorisnika = !tipKorisnika ? TipKorisnika.Prodavac : TipKorisnika.Administrator;

                    k.Obrisan = bool.Parse(row["obrisan"].ToString());
                    korisnikLista.Add(k);
                }
            }

            return korisnikLista;
        }

        public static Korisnik GetById(int id)
        {
            Korisnik korisnik = null;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM korisnik WHERE id = @id; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.Parameters.AddWithValue("id", id);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "korisnik"); // izvrsava se query nad bazom

                // Bice samo jedan red vracen, naravno
                foreach (DataRow row in ds.Tables["korisnik"].Rows)
                {
                    korisnik = new Korisnik();
                    korisnik.Id = int.Parse(row["id"].ToString());
                    korisnik.Ime = row["ime"].ToString();
                    korisnik.Prezime = row["prezime"].ToString();
                    korisnik.KorIme = row["korIme"].ToString();
                    korisnik.Lozinka = row["lozinka"].ToString();

                    bool tipKorisnika = bool.Parse(row["tipKorisnika"].ToString());
                    korisnik.TipKorisnika = !tipKorisnika ? TipKorisnika.Prodavac : TipKorisnika.Administrator;

                    korisnik.Obrisan = bool.Parse(row["obrisan"].ToString());
                }
            }

            return korisnik;
        }

        public static Korisnik Add(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $" INSERT INTO korisnik (ime, prezime, korIme, lozinka, tipKorisnika) " +
                    $"VALUES (@ime, @prezime, @korIme, @lozinka, @tipKorisnika); ";
                cmd.CommandText += " SELECT SCOPE_IDENTITY(); "; // metoda koja uzima identity poslednjeg upisanog elementa

                cmd.Parameters.AddWithValue("ime", k.Ime);
                cmd.Parameters.AddWithValue("prezime", k.Prezime);
                cmd.Parameters.AddWithValue("korIme", k.KorIme);
                cmd.Parameters.AddWithValue("lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("tipKorisnika", k.TipKorisnika == TipKorisnika.Prodavac ? 0 : 1);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar izvrsava query nad bazom
                k.Id = newId;
            }
            Projekat.Instance.KorisnikLista.Add(k); // Azuriram i model!

            return k;
        }

        public static void Update(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " UPDATE korisnik " +
                    "SET ime = @ime, prezime = @prezime, korIme = @korIme, lozinka = @lozinka, tipKorisnika = @tipKorisnika, obrisan = @obrisan  " +
                    "WHERE id = @id; ";

                cmd.Parameters.AddWithValue("ime", k.Ime);
                cmd.Parameters.AddWithValue("prezime", k.Prezime);
                cmd.Parameters.AddWithValue("korIme", k.KorIme);
                cmd.Parameters.AddWithValue("lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("tipKorisnika", k.TipKorisnika == TipKorisnika.Prodavac ? 0 : 1);
                cmd.Parameters.AddWithValue("id", k.Id);
                cmd.Parameters.AddWithValue("obrisan", k.Obrisan);

                cmd.ExecuteNonQuery();

                // Azuriram model, listu u modelu
                // ISPRAVKA : Aj popravi imena tih varijabli, ne zna se ko koga ...
                foreach (Korisnik it in Projekat.Instance.KorisnikLista)
                {
                    if (it.Id == k.Id)
                    {
                        it.Ime = k.Ime;
                        it.Prezime = k.Prezime;
                        it.KorIme = k.KorIme;
                        it.Lozinka = k.Lozinka;
                        it.TipKorisnika = k.TipKorisnika;
                        it.Obrisan = k.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Korisnik k)
        {
            k.Obrisan = true;
            Update(k);
        }



        /*
        public static void Add(Korisnik korisnik)
        {
            korisnik.Id = GetList().Count;
            korisnik.Obrisan = false;
            ObservableCollection<Korisnik> lista = GetList();
            lista.Add(korisnik);
            UpdateList(lista);
        }

        public static void Update(Korisnik korisnik)
        {
            ObservableCollection<Korisnik> list = GetList();
            list[korisnik.Id] = korisnik;
            UpdateList(list);
        }

        public static ObservableCollection<Korisnik> GetList()
        {
            return Projekat.Instance.KorisnikLista;
        }

        public static void UpdateList(ObservableCollection<Korisnik> newList)
        {
            Projekat.Instance.KorisnikLista = newList;
        }

        public static Korisnik GetById(int id)
        {
            Korisnik korisnik = null;
            foreach (Korisnik k in Projekat.Instance.KorisnikLista)
            {
                if (k.Id == id)
                {
                    korisnik = k;
                    break;
                }
            }
            return korisnik;
        }
        */
    }
}
