namespace USTIT.Services.HeadDepartmentAPI.Utility
{
    public static class CustomLibaray
    {
        public static string CreateAbsenseNo(string studentGroupNo,string ceNo,DateTime absenseDate)
        {
            return "A-" + studentGroupNo + '-' + ceNo + '-' + absenseDate.ToString("yyyy-MM-DD");
        }


        //((((((CONVERT([nvarchar](10),[DeptCode])+'-')+CONVERT([nvarchar](4),[AcYear]))+'-')+CONVERT([nvarchar](2),[SemNo]))+'-')+CONVERT([nvarchar](50),[CourseCode]))
        public static string CreateCourseEnrollmentNo(string deptCode,int semseterNo, int academicYear, string courseCode)
        {
            return deptCode + '-' + academicYear + '-' + semseterNo + '-' + courseCode ;
        }
    }
}
