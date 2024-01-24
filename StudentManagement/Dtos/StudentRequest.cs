namespace StudentManagement.Dtos
{
    public class StudentRequest
    {
        private string _studentName;
        public string StudentName
        {
            get => _studentName;
            set => _studentName = value?.Trim();
        }

        private string _studentCode;
        public string StudentCode
        {
            get => _studentCode;
            set => _studentCode = value?.Trim();
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (value < DateTime.Now)
                {
                    _dateOfBirth = value;
                }
                else
                {
                    throw new ArgumentException("BirthOfDate must be before the current date.");
                }
            }
        }
    }
}
