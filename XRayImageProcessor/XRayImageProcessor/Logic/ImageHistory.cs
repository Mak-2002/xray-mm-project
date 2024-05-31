using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;

namespace XRayImageProcessor
{
    public class ImageHistory
    {
        private Stack<Bitmap> historyStack = new Stack<Bitmap>();

        public void SaveState(Bitmap image)
        {
            // Save a clone of the image to ensure we have a copy of the current state
            historyStack.Push((Bitmap)image.Clone());
        }

        public Bitmap? Undo()
        {
            if (historyStack.Count > 1)
            {
                historyStack.Pop(); // Remove the current state
                return (Bitmap)historyStack.Peek().Clone(); // Return the previous state
            }
            else if (historyStack.Count == 1)
            {
                return (Bitmap)historyStack.Peek().Clone(); // Return the only state available
            }

            return null; // No states available
        }

        public void Clear()
        {
            historyStack.Clear();
        }

        public bool CanUndo()
        {
            return historyStack.Count > 1;
        }
    }
}
