using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Comparers
{
    public class TableComparer : IComparer<Table>
    {
        public int Compare(Table x, Table y)
        {
            return string.Compare(x.TableNumber, y.TableNumber);
        }
    }
}
