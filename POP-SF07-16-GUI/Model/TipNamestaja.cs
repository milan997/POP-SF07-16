using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{
    public class TipNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;

        private string naziv;
        
        public TipNamestaja()
        {
            Id = 0;
            Obrisan = false;
            Naziv = "";
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return $"{Naziv}";
        }

        public object Clone()
        {
            return new TipNamestaja()
            {
                id = this.Id,
                naziv = this.Naziv,
                obrisan = this.Obrisan
            };
        }

        #region Database
        public static ObservableCollection<TipNamestaja> GetAll()
        {
            var tipNamestaja = new ObservableCollection<TipNamestaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM tipNamestaja WHERE obrisan = 0";

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
                    tipNamestaja.Add(tn);
                }
            }

            return tipNamestaja;
        }

        public static TipNamestaja Create(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO tipNamestaja (naziv, obrisan) VALUES (@naziv, @obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();"; // metoda koja uzima identity poslednjeg upisanog elementa

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
                cmd.CommandText = "UPDATE tipNamestaja " +
                    "SET naziv = @naziv, obrisan = @obrisan  " +
                    "WHERE id = @id; ";

                cmd.Parameters.AddWithValue("id", tn.Id);
                cmd.Parameters.AddWithValue("naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();

                // Azuriram model, listu u modelu
                // ISPRAVKA : Aj popravi imena tih varijabli, ne zna se ko koga ...
                foreach (var tipNamestaja in Projekat.Instance.TipNamestajaLista)
                {
                    if(tipNamestaja.Id == tn.Id)
                    {
                        tipNamestaja.Naziv = tn.Naziv;
                        tipNamestaja.Obrisan = tn.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Delete(TipNamestaja tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }
        #endregion 
    }
}
