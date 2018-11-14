using Xamarin.Forms;

namespace Timer
{
    public static class GridUtility
    {
        public static RowDefinition StandardRow() => new RowDefinition {Height = new GridLength(1, GridUnitType.Star)};
        public static ColumnDefinition StandardColumn() => new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)};

        public static Grid MakeGrid(int rows, int columns)
        {
            var grid = new Grid();
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(StandardRow());
            }

            for (int j = 0; j < columns; j++)
            {
                grid.ColumnDefinitions.Add(StandardColumn());
            }

            return grid;
        }
    }
}