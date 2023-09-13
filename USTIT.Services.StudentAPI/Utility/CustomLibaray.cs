namespace USTIT.Services.HeadDepartmentAPI.Utility
{
    public static class CustomLibaray
    {
        public static string CreateFullStdId(int academicYear, string departmentCode,int studentNo)
        {
            return academicYear + departmentCode + studentNo.ToString().PadLeft(4, '0');
        }
    }
}
