using System.Data.SqlClient;

namespace SedcLister
{
    internal class SqlBuilder
    {
        internal static void UpdateStudent(SqlConnection cnn, params object[] parameterValues)
        {
            var cmd = new SqlCommand(SqlStrings.UpdateStudent.Query, cnn);
            cmd.SetParameters(SqlStrings.UpdateStudent, parameterValues);
            cmd.ExecuteNonQuery();
        }
    }
}