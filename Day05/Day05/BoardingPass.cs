using System;

namespace Day05
{
    public class BoardingPass
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int SeatId { get; set; }
        public string Input { get; set; }

        public void RowMap()
        {
            var maxRow = 127;
            var minRow = 0;
            var chars = Input.ToCharArray();

            for (var i = 0; i < chars.Length; i++)
            {
                if (chars[i] != 'F' && chars[i] != 'B') continue;
                
                if (chars[i] == 'F')
                {
                    maxRow = (maxRow - minRow) / 2 + minRow;
                }
                else if (chars[i] == 'B')
                {
                    minRow = (maxRow + minRow) / 2 + 1;
                }

                if (maxRow == minRow)
                {
                    Row = maxRow;
                    break;
                }
            }
        }

        public void ColumnMap()
        {
            var maxColumn = 7;
            var minColumn = 0;
            var chars = Input.ToCharArray();

            for (var i = 0; i < chars.Length; i++)
            {
                if (chars[i] != 'L' && chars[i] != 'R') continue;
                
                if (chars[i] == 'L')
                {
                    maxColumn = (maxColumn - minColumn) / 2 + minColumn;
                }
                else if (chars[i] == 'R')
                {
                    minColumn = (maxColumn + minColumn) / 2 + 1;
                }

                if (maxColumn == minColumn)
                {
                    Column = maxColumn;
                    break;
                }
            }
        }

        public void AssignSeatId()
        {
            SeatId = Row * 8 + Column;
        }
    }
}