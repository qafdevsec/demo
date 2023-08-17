public class ReportController : Controller
{
    ...
    public ActionResult GenerateReport(int customerID, string description)
    {
        const string PDF = "/PDF/PDFGenerator.exe";
        
        try
        {
            var xmlFile = GetCustomerXmlData(customerID);
            var outputFile = GenerateTempFileName(customerID);
            var proc = System.Diagnostics.Process.Start("cmd.exe", $"/C {PDF} --xml {xmlFile} --out {outputFile} --desc \"{description}\"");
            proc.WaitForExit();
            return File(outputFile, "application/pdf");
        }
        catch (Exception ex)
        {
            LogException(ex);
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Error occured while generating the report.");
        }
    }
    ...
}
