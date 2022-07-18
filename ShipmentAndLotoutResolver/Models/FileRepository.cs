using System.IO.Compression;

namespace ShipmentAndLotoutResolver.Models
{
    public class FileRepository : IFileRepository
    {
        private readonly IConfiguration configuration;
        public FileRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string? FileName(string InputLot)
        {
            var LotPaths = configuration["Paths:LotPath"];
            string DirectoryPath = LotPaths + InputLot + "\\";
            List<string> ReadFiles = new();
            if (Directory.Exists(DirectoryPath))
            {
                string FilePath = DirectoryPath + InputLot + ".zip";
                if (File.Exists(FilePath))
                {
                    using (ZipArchive zip = ZipFile.Open(FilePath, ZipArchiveMode.Read))
                    {
                        foreach (ZipArchiveEntry entry in zip.Entries)
                        {
                            ReadFiles.Add(entry.ToString());
                        }
                    }
                    if (ReadFiles.Contains("flow_chk.skp"))
                    {
                        return "ทำการแก้ไขปัญหาเรียบร้อยแล้ว หากไม่สามารถใช้งานได้กรุณาติดต่อ System";
                    }
                    else
                    {
                        using (FileStream zipToOpen = new(FilePath, FileMode.Open))
                        {
                            using ZipArchive archive = new(zipToOpen, ZipArchiveMode.Update);
                            ZipArchiveEntry readmeEntry = archive.CreateEntry("flow_chk.skp");
                        }
                        return "true";
                    }
                }
                else
                {
                    return "ไม่พบไฟล์ Zip Lot แก้ไขไม่สำเร็จกรุณาติดต่อ System";
                }
            }
            else
            {
                return "ไม่พบ Folder Lot แก้ไขไม่สำเร็จกรุณาติดต่อ System";
            }
        }
    }
}