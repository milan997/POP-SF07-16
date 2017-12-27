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
    public static class SalonDAO
    {
        public static ObservableCollection<Salon> GetList()
        {
            var salonLista = new ObservableCollection<Salon>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM salon WHERE obrisan = 0; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "salon"); // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["salon"].Rows)
                {
                    var s = new Salon();
                    s.Id = int.Parse(row["id"].ToString());
                    s.Naziv = row["naziv"].ToString();
                    s.Adresa = row["adresa"].ToString();
                    s.Telefon = row["telefon"].ToString();
                    s.Email = row["email"].ToString();
                    s.WebAdresa = row["webAdresa"].ToString();
                    s.Pib = row["pib"].ToString();
                    s.MaticniBroj = row["maticniBroj"].ToString();
                    s.BrRacuna = row["brRacuna"].ToString();
                    s.Obrisan = bool.Parse(row["obrisan"].ToString());
                    salonLista.Add(s);
                }
            }

            return salonLista;
        }

        public static Salon GetById(int id)
        {
            Salon salon = null;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM salon WHERE id = @id; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.Parameters.AddWithValue("id", id);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "salon"); // izvrsava se query nad bazom

                // Bice samo jedan red vracen, naravno
                foreach (DataRow row in ds.Tables["salon"].Rows)
                {
                    salon = new Salon();
                    salon.Id = int.Parse(row["id"].ToString());
                    salon.Naziv = row["naziv"].ToString();
                    salon.Adresa = row["adresa"].ToString();
                    salon.Telefon = row["telefon"].ToString();
                    salon.Email = row["email"].ToString();
                    salon.WebAdresa = row["webAdresa"].ToString();
                    salon.Pib = row["pib"].ToString();
                    salon.MaticniBroj = row["maticniBroj"].ToString();
                    salon.BrRacuna = row["brRacuna"].ToString();
                    salon.Obrisan = bool.Parse(row["obrisan"].ToString());


                }
            }

            return salon;
        }

        public static Salon Add(Salon salon)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $" INSERT INTO salon (naziv, adresa, telefon, email, webAdresa, pib, maticniBroj, brRacuna) " +
                    $"VALUES (@naziv, @adresa, @telefon, @email, @webAdresa, @pib, @maticniBroj, @brRacuna); ";
                cmd.CommandText += " SELECT SCOPE_IDENTITY(); "; // metoda koja uzima identity poslednjeg upisanog elementa

                cmd.Parameters.AddWithValue("naziv", salon.Naziv);
                cmd.Parameters.AddWithValue("adresa", salon.Adresa);
                cmd.Parameters.AddWithValue("telefon", salon.Telefon);
                cmd.Parameters.AddWithValue("email", salon.Email);
                cmd.Parameters.AddWithValue("webAdresa", salon.WebAdresa);
                cmd.Parameters.AddWithValue("pib", salon.Pib);
                cmd.Parameters.AddWithValue("maticniBroj", salon.MaticniBroj);
                cmd.Parameters.AddWithValue("brRacuna", salon.BrRacuna);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar izvrsava query nad bazom
                salon.Id = newId;
            }
            Projekat.Instance.SalonLista.Add(salon); // Azuriram i model!

            return salon;
        }

        public static void Update(Salon s)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " UPDATE salon " +
                    "SET naziv = @naziv, adresa = @adresa, telefon = @telefon, email = @email, " +
                        "webAdresa = @webAdresa, pib = @pib, maticniBroj = @maticniBroj, brRacuna = @brRacuna, obrisan = @obrisan  " +
                    "WHERE id = @id; ";

                cmd.Parameters.AddWithValue("naziv", s.Naziv);
                cmd.Parameters.AddWithValue("adresa", s.Adresa);
                cmd.Parameters.AddWithValue("telefon", s.Telefon);
                cmd.Parameters.AddWithValue("email", s.Email);
                cmd.Parameters.AddWithValue("webAdresa", s.WebAdresa);
                cmd.Parameters.AddWithValue("pib", s.Pib);
                cmd.Parameters.AddWithValue("maticniBroj", s.MaticniBroj);
                cmd.Parameters.AddWithValue("brRacuna", s.BrRacuna);
                cmd.Parameters.AddWithValue("obrisan", s.Obrisan);
                cmd.Parameters.AddWithValue("id", s.Id);

                cmd.ExecuteNonQuery();

                // Azuriram model, listu u modelu
                // ISPRAVKA : Aj popravi imena tih varijabli, ne zna se ko koga ...
                foreach (Salon it in Projekat.Instance.SalonLista)
                {
                    if (it.Id == s.Id)
                    {
                        it.Naziv = s.Naziv;
                        it.Adresa = s.Adresa;
                        it.Telefon = s.Telefon;
                        it.Email = s.Email;
                        it.WebAdresa = s.WebAdresa;
                        it.Pib = s.Pib;
                        it.MaticniBroj = s.MaticniBroj;
                        it.BrRacuna = s.BrRacuna;
                        it.Obrisan = s.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Salon s)
        {
            s.Obrisan = true;
            Update(s);
        }




        /*
        public static void Add(Salon salon)
        {
            salon.Id = GetList().Count;
            salon.Obrisan = false;
            ObservableCollection<Salon> lista = GetList();
            lista.Add(salon);
            UpdateList(lista);
        }

        public static void Update(Salon salon)
        {
            ObservableCollection<Salon> list = GetList();
            list[salon.Id] = salon;
            UpdateList(list);
        }

        public static ObservableCollection<Salon> GetList()
        {
            return Projekat.Instance.SalonLista;
        }

        public static void UpdateList(ObservableCollection<Salon> newList)
        {
            Projekat.Instance.SalonLista = newList;
        }
        */
    }
}
