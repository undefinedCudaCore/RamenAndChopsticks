namespace RamenAndChopsticks.Contracts
{
    public interface IDataFile
    {
        public List<string> DataFileNames();
        public List<string> CheckFilesExists(List<string> dataFileList);
        public bool DataFilesCreated(List<string> dataFileList);
    }
}
