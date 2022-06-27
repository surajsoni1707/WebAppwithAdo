using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppwithAdo.Models
{
    public class CourseDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public CourseDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Course> GetAllCourse()
        {
            List<Course> list = new List<Course>();
            string query = "select * from course";
            cmd =new SqlCommand(query, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    Course cd = new Course();
                    cd.Id = Convert.ToInt32(dr["id"]);
                    cd.Name = dr["Name"].ToString();
                    cd.Fees = Convert.ToSingle(dr["Fees"]);
                    list.Add(cd);
                    
                }
                con.Close();
                return list;

            }
            con.Close();
            return list;
        }
        public int Save(Course c)
        {
            string query = "insert into course values(@name,@Fees)";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", c.Name);
            cmd.Parameters.AddWithValue("@Fees", c.Fees);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public Course GetCourseById(int id)
        {
            Course c = new Course();
            string query = "select * from Course where id=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    c.Id = Convert.ToInt32(dr["id"]);
                    c.Name = dr["name"].ToString();
                    c.Fees = Convert.ToSingle(dr["Fees"]);
                }
                con.Close();
                return c;
            }
            con.Close();
            return c;
        }
        public int Update(Course c)
        {
            string query = "update Course set name=@name,Fees=@Fees where id=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", c.Id);
            cmd.Parameters.AddWithValue("@name", c.Name);
            cmd.Parameters.AddWithValue("@Fees", c.Fees);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int id)
        {
            string query = "Delete From Course where id=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

    }
}
