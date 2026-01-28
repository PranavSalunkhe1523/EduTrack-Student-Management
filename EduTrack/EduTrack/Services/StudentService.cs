using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EduTrack.Data;
using EduTrack.Models;

namespace EduTrack.Services
{
    internal class StudentService
    {
        public static void AddStudent(Student student)
        {
            string query = @"INSERT INTO Students 
                             (StudentId, FullName, Gender, Age, Course, Email, Phone, Marks)
                             VALUES 
                             (@StudentId, @FullName, @Gender, @Age, @Course, @Email, @Phone, @Marks)";

            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmd.Parameters.AddWithValue("@FullName", student.FullName);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Course", student.Course);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Phone", student.Phone);
                cmd.Parameters.AddWithValue("@Marks", student.Marks);

                cmd.ExecuteNonQuery();
            }
        }

        public static List<Student> GetAllStudent()
        {
            List<Student> students = new List<Student>();
            string query = "select * from Students";

            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Student s= new Student();
                    s.StudentId = Convert.ToInt32(reader["StudentID"]);
                    s.FullName = reader["FullName"].ToString();
                    s.Gender = reader["Gender"].ToString();
                    s.Age = Convert.ToInt32(reader["Age"]);
                    s.Course = reader["Course"].ToString() ;
                    s.Email = reader["Email"].ToString();
                    s.Phone = Convert.ToInt64(reader["Phone"]);
                    s.Marks = Convert.ToInt32(reader["Marks"]);

                    students.Add(s);
                }
            }
            return students;
        }

        public static Student GetStudentById(int id)
        {
            Student s = null;
            string query = "SELECT * FROM Students WHERE StudentId = @StudentId";

            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    s = new Student
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        FullName = reader["FullName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Course = reader["Course"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = Convert.ToInt64(reader["Phone"]),
                        Marks = Convert.ToInt32(reader["Marks"])
                    };
                }
            }

            return s;
        }

        public static void UpdateStudent(Student student)
        {
            string query = @"UPDATE Students 
                     SET FullName = @FullName,
                         Gender = @Gender,
                         Age = @Age,
                         Course = @Course,
                         Email = @Email,
                         Phone = @Phone,
                         Marks = @Marks
                     WHERE StudentId = @StudentId";

            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmd.Parameters.AddWithValue("@FullName", student.FullName);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Course", student.Course);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Phone", student.Phone);
                cmd.Parameters.AddWithValue("@Marks", student.Marks);

                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteStudent(int id)
        {
            string query = "Delete from students where studentID = @StudentID";

            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentId", id);

                cmd.ExecuteNonQuery();
            }
        }
        public static Student SearchStudent(int id)
        {
            Student s = null;
            string query = "SELECT * FROM Students WHERE StudentId = @StudentId";

            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    s = new Student
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        FullName = reader["FullName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Course = reader["Course"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = Convert.ToInt64(reader["Phone"]),
                        Marks = Convert.ToInt32(reader["Marks"])
                    };
                }
            }
            return s;
        }

        public static List<Student> SearchStudentsByName(string name)
        {
            List<Student> list = new List<Student>();
            string query = "SELECT * FROM Students WHERE FullName LIKE @Name";

            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", "%" + name + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        FullName = reader["FullName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Course = reader["Course"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = Convert.ToInt64(reader["Phone"]),
                        Marks = Convert.ToInt32(reader["Marks"])
                    };
                    list.Add(s);
                }
            }
            return list;
        }

    }
}
