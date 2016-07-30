namespace ADMS.Domain.Interfaces.Files
{
    public interface IThumbnailGenerator
    {
        bool GenerateThumbnail(string sourceFilePath, string destinationDirectory, int widthPX, int heightPX);
    }
}
