namespace BuildingBlocks.Utilities.Formaters.Csv
{
    public interface ICsv
    {
        string ToCsvHeader(object obj);

        string ToCsvRow(object obj);
    }
}
