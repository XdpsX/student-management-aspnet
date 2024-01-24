using Microsoft.AspNetCore.Mvc;
using StudentManagement.Dtos;
using StudentManagement.Entities;
using System.Xml.Linq;

namespace StudentManagement.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentController : Controller
    {
        private static int _id = 0;
        private static List<Student> _students = new List<Student>();

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_students);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentRequest input)
        {
            Student student = new Student();
            student.Id = _id++;
            student.Name = input.StudentName;
            student.StudentCode = input.StudentCode;
            student.DateOfBirth = input.DateOfBirth;
            _students.Add(student);

            return Ok(student); 
        }

        [HttpGet("path-id/{id}")]
        public IActionResult getStudentByIdInPath(int id)
        {
            var student = _students.Find(s => s.Id == id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpGet("param-id")]
        public IActionResult getStudentByIdInParam([FromQuery] int id)
        {
            var student = _students.Find(s => s.Id == id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult updateStudentById(int id, [FromBody] StudentRequest student)
        {
            var existingStudent = _students.Find(s => s.Id == id);
            if (existingStudent == null)
                return NotFound();

            existingStudent.Name = student.StudentName;
            existingStudent.StudentCode = student.StudentCode;
            existingStudent.DateOfBirth = student.DateOfBirth;

            return Ok(existingStudent);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            var sinhVien = _students.Find(sv => sv.Id == id);
            if (sinhVien == null)
                return NotFound();

            _students.Remove(sinhVien);
            return Ok();
        }
    }
}
