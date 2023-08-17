public async Task<IActionResult> compressAndDownloadFile()
{

  string filePath = Request.Query["filePath"];
  procStartInfo = new System.Diagnostics.ProcessStartInfo(
    "/bin/bash",
    $"-c \"cat {filePath} | gzip > {filePath}.gz\""
  );
  procStartInfo.UseShellExecute = false;
  procStartInfo.CreateNoWindow = true;
  System.Diagnostics.Process proc = new System.Diagnostics.Process();
  proc.StartInfo = procStartInfo;
  proc.Start();
  proc.WaitForExit();

  return File($"{filePath}.gz", "application/gzip");
}

