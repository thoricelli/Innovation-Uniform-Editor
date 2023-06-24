using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor
{
    public class DraggablePanel : Panel
    {
        private Point dragStartPoint;

        public DraggablePanel()
        {
            // Subscribe to mouse events
            this.MouseDown += DraggablePanel_MouseDown;
            this.MouseMove += DraggablePanel_MouseMove;
        }

        private void DraggablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Store the starting point of the drag operation
            dragStartPoint = new Point(e.X, e.Y);
        }

        private void DraggablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is pressed
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the new position of the panel
                int newX = this.Left + (e.X - dragStartPoint.X);
                int newY = this.Top + (e.Y - dragStartPoint.Y);

                // Move the panel to the new position
                this.Location = new Point(newX, newY);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
