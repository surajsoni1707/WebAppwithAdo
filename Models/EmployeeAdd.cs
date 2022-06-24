using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppwithAdo.Models
{
    public class EmployeeAdd
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public EmployeeAdd()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Employee> GetAllProducts()
        {
            List<Employee> list = new List<Employee>();
            string str = "select * from Employee";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee p = new Employee();
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["Name"].ToString();
                    p.Salary = Convert.ToSingle(dr["salary"]);
                    list.Add(p);
                }
                con.Close();
                return list;
            }
            else
            {
                con.Close();
                return list;
            }
        }
        public Employee GetProductById(int id)
        {
            Employee p = new Employee();
            string str = "select * from Employee where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.Name = dr["Name"].ToString();
                    p.Salary = Convert.ToSingle(dr["Salary"]);

                }
                con.Close();
                return p;
            }
            else
            {
                con.Close();
                return p;

            }

        }
        public int Save(Employee prod)
        {
            string str = "insert into Employee values(@name,@salary)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@salary", prod.Salary);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int update(Employee prod)
        {
            string str = "update Employee set Name=@name,Salary=@salary where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", prod.Id);
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@salary", prod.Salary);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int Delete(int id)
        {
            string str = "delete from Employee where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
    }

}
