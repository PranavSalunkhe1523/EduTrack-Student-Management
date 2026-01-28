using EduTrack.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Models;
using EduTrack.Services;
using EduTrack.Utils;
using System.Runtime.InteropServices;

namespace EduTrack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== EduTrack : Student Management System =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Serach Student");
                Console.WriteLine("6. Exit");
                Console.Write("Enetr your choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Student s = new Student();

                        s.StudentId = InputValidator.GetValidInt("Enter Student ID: ");
                        s.FullName = InputValidator.GetNonEmptystring("Enter Full Name: ");
                        s.Gender = InputValidator.GetNonEmptystring("Enter Gender: ");
                        s.Age = InputValidator.GetvalidRangeInt("Enter Age (1-100): ", 1, 100);
                        s.Course = InputValidator.GetNonEmptystring("Enter Course: ");
                        s.Email = InputValidator.GetvalidEmail("Enter Email: ");
                        s.Phone = InputValidator.GetvalidPhone("Enter Phone (10 digits): ");
                        s.Marks = InputValidator.GetvalidRangeInt("Enter Marks (0-100): ", 0, 100);

                        StudentService.AddStudent(s);
                        Console.WriteLine("Student added successfully!");
                        break;

                    case 2:
                        var students = StudentService.GetAllStudent();

                        Console.WriteLine("\n===== All Students =====\n");

                       foreach( var st in students)
                        {
                            Console.WriteLine("ID: " + st.StudentId);
                            Console.WriteLine("Name: "+ st.FullName);
                            Console.WriteLine("Gender: "+st.Gender);
                            Console.WriteLine("Age: "+st.Age);
                            Console.WriteLine("Course: "+st.Course);
                            Console.WriteLine("Email: "+st.Email);
                            Console.WriteLine("Phone: "+st.Phone);
                            Console.WriteLine("Marks: " + st.Marks);
                            Console.WriteLine("---------------------------");
                        }
                        break;

                    case 3:
                        Console.Write("Enter Student ID to Update: ");
                        int id = InputValidator.GetValidInt("");

                        Student old = StudentService.GetStudentById(id);

                        if (old == null)
                        {
                            Console.WriteLine("Student not found!");
                            break;
                        }

                        Student u = new Student();
                        u.StudentId = id;

                        u.FullName = InputValidator.GetOptionalString($"Full Name ({old.FullName}): ", old.FullName);
                        u.Gender = InputValidator.GetOptionalString($"Gender ({old.Gender}): ", old.Gender);
                        u.Age = InputValidator.GetOptionalRangeInt($"Age ({old.Age}): ", old.Age, 1, 100);
                        u.Course = InputValidator.GetOptionalString($"Course ({old.Course}): ", old.Course);
                        u.Email = InputValidator.GetOptionalEmail($"Email ({old.Email}): ", old.Email);
                        u.Phone = InputValidator.GetOptionalPhone($"Phone ({old.Phone}): ", old.Phone);
                        u.Marks = InputValidator.GetOptionalRangeInt($"Marks ({old.Marks}): ", old.Marks, 0, 100);

                        StudentService.UpdateStudent(u);
                        Console.WriteLine("Student updated successfully!");
                        break;


                    case 4:
                        Console.Write("Enter Student ID to Delete: ");
                        int delId = InputValidator.GetValidInt("");

                        Student delStudent = StudentService.GetStudentById(delId);

                        if (delStudent == null)
                        {
                            Console.WriteLine("Student not found!");
                            break;
                        }

                        Console.WriteLine("\nStudent Details:");
                        Console.WriteLine("ID: " + delStudent.StudentId);
                        Console.WriteLine("Name: " + delStudent.FullName);
                        Console.WriteLine("Course: " + delStudent.Course);
                        Console.WriteLine("Marks: " + delStudent.Marks);

                        Console.Write("\nAre you sure you want to delete this student? (Y/N): ");
                        string confirm = Console.ReadLine();

                        if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            StudentService.DeleteStudent(delId);
                            Console.WriteLine("Student deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Delete operation cancelled.");
                        }
                        break;


                    case 5:
                        Console.WriteLine("Search Student By:");
                        Console.WriteLine("1. ID");
                        Console.WriteLine("2. Name");
                        Console.Write("Choose option: ");
                        int searchChoice = InputValidator.GetValidInt("");

                        if (searchChoice == 1)
                        {
                            Console.Write("Enter Student ID: ");
                            int sid = InputValidator.GetValidInt("");

                            Student found = StudentService.GetStudentById(sid);

                            if (found != null)
                            {
                                Console.WriteLine("\nStudent Found:");
                                Console.WriteLine("ID: " + found.StudentId);
                                Console.WriteLine("Name: " + found.FullName);
                                Console.WriteLine("Course: " + found.Course);
                                Console.WriteLine("Marks: " + found.Marks);
                            }
                            else
                            {
                                Console.WriteLine("Student not found!");
                            }
                        }
                        else if (searchChoice == 2)
                        {
                            Console.Write("Enter Name to Search: ");
                            string name = Console.ReadLine();

                            var results = StudentService.SearchStudentsByName(name);

                            if (results.Count > 0)
                            {
                                Console.WriteLine("\nMatching Students:");
                                foreach (var st in results)
                                {
                                    Console.WriteLine("ID: " + st.StudentId + " | Name: " + st.FullName +
                                                      " | Course: " + st.Course + " | Marks: " + st.Marks);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No students found with this name.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid search option.");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Thank You for using EduTrack!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
                Console.WriteLine("\nPreass Enter to continue...");
                Console.ReadLine();

                /*try
                {
                    using (SqlConnection con = DbHelper.GetConnection())
                    {
                        con.Open();
                        Console.WriteLine("Database connected successfully!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
                Console.ReadLine();*/
            }

        }
    }
}
