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
    public static class NamestajDAO
    {
        public static ObservableCollection<Namestaj> GetList()
        {
            var namestajLista = new ObservableCollection<Namestaj>();
            object value;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM namestaj WHERE obrisan = 0; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "namestaj"); // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = int.Parse(row["id"].ToString());
                    n.Obrisan = bool.Parse(row["obrisan"].ToString());
                    n.Naziv = row["naziv"].ToString();
                    n.Sifra = row["sifra"].ToString();
                    n.Cena = double.Parse(row["cena"].ToString());
                    n.KolicinaUMagacinu = int.Parse(row["kolicina"].ToString());

                    value = row["tipNamestaja_id"];
                    n.TipNamestaja = value != DBNull.Value ? TipNamestajaDAO.GetById(int.Parse(value.ToString())) : null;

                    value = row["akcija_id"];
                    n.Akcija = value != DBNull.Value ? AkcijaDAO.GetById(int.Parse(value.ToString())) : null;

                    namestajLista.Add(n);
                }
            }

            return namestajLista;
        }

        public static Namestaj GetById(int id)
        {
            Namestaj namestaj = null;
            object value;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM namestaj WHERE id = @id; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.Parameters.AddWithValue("id", id);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "namestaj"); // izvrsava se query nad bazom

                // Bice samo jedan red vracen, naravno
                foreach (DataRow row in ds.Tables["namestaj"].Rows)
                {
                    namestaj = new Namestaj();
                    namestaj.Id = int.Parse(row["id"].ToString());
                    namestaj.Obrisan = bool.Parse(row["obrisan"].ToString());
                    namestaj.Naziv = row["naziv"].ToString();
                    namestaj.Sifra = row["sifra"].ToString();
                    namestaj.Cena = double.Parse(row["cena"].ToString());
                    namestaj.KolicinaUMagacinu = int.Parse(row["kolicina"].ToString());

                    value = row["tipNamestaja_id"];
                    namestaj.TipNamestaja = value != DBNull.Value ? TipNamestajaDAO.GetById(int.Parse(value.ToString())) : null;

                    value = row["akcija_id"];
                    namestaj.Akcija = value != DBNull.Value ? AkcijaDAO.GetById(int.Parse(value.ToString())) : null;
                }
            }

            return namestaj;
        }

        public static Namestaj Add(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $" INSERT INTO namestaj (naziv, sifra, cena, kolicina, tipNamestaja_id, akcija_id) " +
                    $"VALUES (@naziv, @sifra, @cena, @kolicina, @tipNamestaja_id, @akcija_id) ; ";
                cmd.CommandText += " SELECT SCOPE_IDENTITY(); "; // metoda koja uzima identity poslednjeg upisanog elementa

                cmd.Parameters.AddWithValue("naziv", n.Naziv);
                cmd.Parameters.AddWithValue("sifra", n.Sifra);
                cmd.Parameters.AddWithValue("cena", n.Cena);
                cmd.Parameters.AddWithValue("kolicina", n.KolicinaUMagacinu);

                if (n.TipNamestaja != null)
                    cmd.Parameters.AddWithValue("tipNamestaja_id", n.TipNamestaja.Id);
                else
                    cmd.Parameters.AddWithValue("tipNamestaja_id", DBNull.Value);

                if (n.Akcija != null)
                    cmd.Parameters.AddWithValue("akcija_id", n.Akcija.Id);
                else
                    cmd.Parameters.AddWithValue("akcija_id", DBNull.Value);


                int newId = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar izvrsava query nad bazom
                n.Id = newId;
            }
            Projekat.Instance.NamestajLista.Add(n); // Azuriram i model!

            return n;
        }

        public static void Update(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " UPDATE namestaj " +
                    "SET naziv = @naziv, sifra = @sifra, cena = @cena, kolicina = @kolicina, " +
                        "tipNamestaja_id = @tipNamestaja_id, akcija_id = @akcija_id  " +
                    "WHERE id = @id; ";

                cmd.Parameters.AddWithValue("id", n.Id);
                cmd.Parameters.AddWithValue("naziv", n.Naziv);
                cmd.Parameters.AddWithValue("sifra", n.Sifra);
                cmd.Parameters.AddWithValue("cena", n.Cena);
                cmd.Parameters.AddWithValue("kolicina", n.KolicinaUMagacinu);

                if (n.TipNamestaja != null)
                    cmd.Parameters.AddWithValue("tipNamestaja_id", n.TipNamestaja.Id);
                else
                    cmd.Parameters.AddWithValue("tipNamestaja_id", DBNull.Value);

                if (n.Akcija != null)
                    cmd.Parameters.AddWithValue("akcija_id", n.Akcija.Id);
                else
                    cmd.Parameters.AddWithValue("akcija_id", DBNull.Value);

                cmd.ExecuteNonQuery();

                // Azuriram model, listu u modelu
                // ISPRAVKA : Aj popravi imena tih varijabli, ne zna se ko koga ...
                foreach (Namestaj it in Projekat.Instance.NamestajLista)
                {
                    if (it.Id == n.Id)
                    {
                        it.Naziv = n.Naziv;
                        it.Sifra = n.Sifra;
                        it.Cena = n.Cena;
                        it.KolicinaUMagacinu = n.KolicinaUMagacinu;
                        it.TipNamestaja = n.TipNamestaja;
                        it.Akcija = n.Akcija;
                        it.Obrisan = n.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }


        /*
        public static void Add(Namestaj namestaj)
        {
            namestaj.Id = GetList().Count;
            namestaj.Obrisan = false;
            ObservableCollection<Namestaj> lista = GetList();
            lista.Add(namestaj);
            UpdateList(lista);
        }

        public static void Update(Namestaj namestaj)
        {
            ObservableCollection<Namestaj> list = GetList();
            list[namestaj.Id] = namestaj;
            UpdateList(list);
        }

        public static ObservableCollection<Namestaj> GetList()
        {
            return Projekat.Instance.NamestajLista;
        }

        public static void UpdateList(ObservableCollection<Namestaj> newList)
        {
            Projekat.Instance.NamestajLista = newList;
        }

        public static Namestaj GetById(int id)
        {
            Namestaj namestaj = null;
            foreach (Namestaj n in GetList())
            {
                if (n.Id == id)
                {
                    namestaj = n;
                    break;
                }
            }
            return namestaj;
        }
        */
    }
}
