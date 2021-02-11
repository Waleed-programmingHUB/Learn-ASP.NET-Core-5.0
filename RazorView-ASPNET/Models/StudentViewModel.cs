using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorView_ASPNET.Models
{
    public class StudentViewModel
    {
        // Connection String
        string connectionString = @"Data Source=DESKTOP-PC-ALI;Initial Catalog=RazorView_ASPNETCore;Integrated Security=True";
        // Show List the Students
        public List<StudentModel> ShowStudents()
        {
            List<StudentModel> student = new List<StudentModel>();
            // SQL Query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string select = "usp_Student_GetAllStudents"; // Select Query Procedure Type in SQL
                using (SqlCommand command = new SqlCommand(select,connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    // DataReading
                    SqlDataReader reader = command.ExecuteReader();
                    // Loop
                    while (reader.Read())
                    {
                        StudentModel studentModel = new StudentModel();
                        studentModel.roll_number = Convert.ToInt32(reader["roll_number"]);
                        studentModel.name = reader["name"].ToString();
                        studentModel.subjects = reader["subjects"].ToString();
                        studentModel.class_name = reader["class_name"].ToString();
                        studentModel.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

                        student.Add(studentModel);
                    }
                }
            }
            return student;
        }

        public void UpdateStudent(StudentModel u_student)
        {
            // SQL Query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Update the Student 
                string insert = "usp_Student_UpdateStudent"; // Select Query Procedure Type in SQL
                using (SqlCommand command = new SqlCommand(insert, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();

                    // Update the Student Value
                    command.Parameters.AddWithValue("@roll_number", u_student.roll_number);
                    command.Parameters.AddWithValue("@name", u_student.name);
                    command.Parameters.AddWithValue("@class_name", u_student.class_name);
                    command.Parameters.AddWithValue("@subjects", u_student.subjects);
                    command.Parameters.AddWithValue("@DateOfBirth", u_student.DateOfBirth);
                    // Execute Query
                    command.ExecuteNonQuery();
                }
            }
        }


        // Insert Student Registration
        public void _RegisterStudent(StudentModel studentModel)
        {
            // SQL Query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insert = "usp_Student_InsertStudent"; // Select Query Procedure Type in SQL
                using (SqlCommand command = new SqlCommand(insert, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();

                        // Add Value
                        command.Parameters.AddWithValue("@name",studentModel.name);
                        command.Parameters.AddWithValue("@class_name",studentModel.class_name);
                        command.Parameters.AddWithValue("@subjects",studentModel.subjects);
                        command.Parameters.AddWithValue("@DateOfBirth",studentModel.DateOfBirth);
                    // Execute Query
                    command.ExecuteNonQuery();
                }
            }
        }



        // Edit Function
        public StudentModel _EditStudent(int roll_number)
        {
            StudentModel studentModel = new StudentModel();
            // SQL Query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string edit = "usp_Student_EditByStudentId"; // Select Query Procedure Type in SQL
                using (SqlCommand command = new SqlCommand(edit, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();

                    // Set the Value Which student roll number you clicked
                    command.Parameters.AddWithValue("@roll_number",roll_number);

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read(); // Show the Input Update Inputs here
                    // Add Value
                    studentModel.roll_number = Convert.ToInt32(reader["roll_number"]);
                    studentModel.name = reader["name"].ToString();
                    studentModel.subjects = reader["subjects"].ToString();
                    studentModel.class_name = reader["class_name"].ToString();
                    studentModel.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                  
                }
            }
                return studentModel;
        }

        // Delete Record Student
        public void _DeleteStudent(int roll_number)
        {
            // SQL Query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string delete = "usp_Student_DeleteStudent"; // Select Query Procedure Type in SQL
                using (SqlCommand command = new SqlCommand(delete, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();

                    // Add Value
                    command.Parameters.AddWithValue("@roll_number", roll_number);

                    // Execute Query
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

