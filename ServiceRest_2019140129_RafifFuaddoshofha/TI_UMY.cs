using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceRest_2019140129_RafifFuaddoshofha
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TI_UMY : ITI_UMY
    {
        public string CreateMahasiswa(Mahasiswa mhs)
        {
            string msg = "GAGAL";
            SqlConnection sqlcon = new SqlConnection("Data Source=LAPTOP-ILNEA6L8; Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=Beauty123");
            string query = String.Format("insert into dbo.Mahasiswa values ('{0}', '{1}', '{2}', '{3}')", mhs.nama, mhs.nim, mhs.prodi, mhs.angkatan);
            //NIM = '{@}"", nim) // string query = "insert into dbo.Mahasiswa values ("* +mhs.nama+", "+mhs.nim+"", ""+mhs.prodi+"", ""+mhs.angkatan+"")"; 
            SqlCommand sqlcom = new SqlCommand(query, sqlcon); //yang dikirim ke sql
            try
            {
                sqlcon.Open(); //membuka connection sql
                Console.WriteLine(query);
                sqlcom.ExecuteNonQuery(); //mengeksuksi untuk memasukkan data
                sqlcon.Close();
                msg = "Sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
                msg = "GAGAL";

            }
            return msg;
        }

        public List<Mahasiswa> GetAllMahasiswa()
        {
            List<Mahasiswa> mahas = new List<Mahasiswa>();
            SqlConnection con = new SqlConnection("Data source=LAPTOP-ILNEA6L8; Initial catalog=\"TI UMY\";Persist Security Info=True; User ID=sa; Password=Beauty123");
            string query = "select Nama, NIM, Prodi, Angkatan from dbo.Mahasiswa";
            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Mahasiswa mhs = new Mahasiswa();
                    mhs.nama = reader.GetString(0);
                    mhs.nim = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);
                    mahas.Add(mhs);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return mahas; //output
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Mahasiswa GetMahasiswaByNIM(string nim)
        {

            Mahasiswa mhs = new Mahasiswa(); SqlConnection con = new SqlConnection("Data source=LAPTOP-ILNEA6L8; Initial catalog=\"TI UMY\";Persist Security Info=True; User ID=sa; Password=Beauty123");
            string query = String.Format("select Nama, NIM, Prodi, Angkatan from dbo.Mahasiswa where NIM = '{0}'", nim);
            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    mhs.nama = reader.GetString(0);
                    mhs.nim = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return mhs;
        }
    }
}
