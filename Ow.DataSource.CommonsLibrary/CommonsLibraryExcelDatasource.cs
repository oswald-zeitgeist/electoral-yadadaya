namespace Ow.DataSource.CommonsLibrary
{
    public static class CommonsLibraryExcelDatasource
    {
        public static bool IsNullOrEmpty(string candidate) => string.IsNullOrEmpty(candidate) || candidate == "NA";
    }
}