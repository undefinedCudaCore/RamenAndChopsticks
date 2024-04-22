namespace RamenAndChopsticks.Contracts
{
    public interface IDataFile
    {
        public List<string> DataFileNames();
        public List<string> CheckFilesExists(List<string> dataFileList);
        public void CreateDataFilePathAndFilesIfNotExists(List<string> dataFileList);
    }
}
