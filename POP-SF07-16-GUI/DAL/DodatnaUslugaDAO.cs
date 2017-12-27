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
    public static class DodatnaUslugaDAO
    {
        public static ObservableCollection<DodatnaUsluga> GetList()
        {
            var dodatnaUslugaLista = new ObservableCollection<DodatnaUsluga>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM dodatnaUsluga WHERE obrisan = 0; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "dodatnaUsluga"); // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["dodatnaUsluga"].Rows)
                {
                    var du = new DodatnaUsluga();
                    du.Id = int.Parse(row["id"].ToString());
                    du.Naziv = row["naziv"].ToString();
                    du.Cena = double.Parse(row["cena"].ToString());
                    du.Obrisan = bool.Parse(row["obrisan"].ToString());
                    dodatnaUslugaLista.Add(du);
                }
            }

            return dodatnaUslugaLista;
        }

        public static DodatnaUsluga GetById(int id)
        {
            DodatnaUsluga dodatnaUsluga = null;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " SELECT * FROM dodatnaUsluga WHERE id = @id; ";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.Parameters.AddWithValue("id", id);

                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "dodatnaUsluga"); // izvrsava se query nad bazom

                // Bice samo jedan red vracen, naravno
                foreach (DataRow row in ds.Tables["dodatnaUsluga"].Rows)
                {
                    dodatnaUsluga = new DodatnaUsluga();
                    dodatnaUsluga.Id = int.Parse(row["id"].ToString());
                    dodatnaUsluga.Cena = double.Parse(row["cena"].ToString());
                    dodatnaUsluga.Naziv = row["naziv"].ToString();
                    dodatnaUsluga.Obrisan = bool.Parse(row["obrisan"].ToString());
                }
            }

            return dodatnaUsluga;
        }

        public static DodatnaUsluga Add(DodatnaUsluga du)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $" INSERT INTO dodatnaUsluga (naziv, cena) " +
                    $"VALUES (@naziv, @cena); ";
                cmd.CommandText += " SELECT SCOPE_IDENTITY(); "; // metoda koja uzima identity poslednjeg upisanog elementa

                cmd.Parameters.AddWithValue("naziv", du.Naziv);
                cmd.Parameters.AddWithValue("cena", du.Cena);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar izvrsava query nad bazom
                du.Id = newId;
            }
            Projekat.Instance.DodatnaUslugaLista.Add(du); // Azuriram i model!

            return du;
        }

        public static void Update(DodatnaUsluga a)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " UPDATE dodatnaUsluga " +
                    "SET naziv = @naziv, cena = @cena, obrisan = @obrisan  " +
                    "WHERE id = @id; ";

                cmd.Parameters.AddWithValue("naziv", a.Naziv);
                cmd.Parameters.AddWithValue("cena", a.Cena);

                cmd.Parameters.AddWithValue("id", a.Id);
                cmd.Parameters.AddWithValue("obrisan", a.Obrisan);

                cmd.ExecuteNonQuery();

                // Azuriram model, listu u modelu
                // ISPRAVKA : Aj popravi imena tih varijabli, ne zna se ko koga ...
                foreach (DodatnaUsluga it in Projekat.Instance.DodatnaUslugaLista)
                {
                    if (it.Id == a.Id)
                    {
                        it.Naziv = a.Naziv;
                        it.Cena = a.Cena;
                        it.Obrisan = a.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(DodatnaUsluga du)
        {
            du.Obrisan = true;
            Update(du);
        }





        /*
        public static void Add(DodatnaUsluga dodatnaUsluga)
        {
            dodatnaUsluga.Id = GetList().Count;
            dodatnaUsluga.Obrisan = false;
            ObservableCollection<DodatnaUsluga> list = GetList();
            list.Add(dodatnaUsluga);
            UpdateList(list);
        }

        public static void Update(DodatnaUsluga dodatnaUsluga)
        {
            ObservableCollection<DodatnaUsluga> list = GetList();
            list[dodatnaUsluga.Id] = dodatnaUsluga;
            UpdateList(list);
        }

        public static ObservableCollection<DodatnaUsluga> GetList()
        {
            return Projekat.Instance.DodatnaUslugaLista;
        }

        public static void UpdateList(ObservableCollection<DodatnaUsluga> newList)
        {
            Projekat.Instance.DodatnaUslugaLista = newList;
        }

        public static DodatnaUsluga GetById(int id)
        {
            DodatnaUsluga dodatnaUsluga = null;
            foreach (DodatnaUsluga du in GetList())
            {
                if (du.Id == id)
                {
                    dodatnaUsluga = du;
                    break;
                }
            }
            return dodatnaUsluga;
        }
        */
    }
}
