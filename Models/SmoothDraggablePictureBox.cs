namespace ThreeCountriesOneCheckpoint.Models
{
    public class SmoothDraggablePictureBox : PictureBox
    {
        private float friction = 0.4f;
        private float stiffness = 0.5f;
        private PointF velocity;
        private PointF targetPosition;
        private PointF currentPosition;
        private bool isDragging = false;
        private Point dragStartPoint;
        private System.Windows.Forms.Timer physicsTimer;
        private Point originalPosition;
        private bool isInRightHalf = false;

        public SmoothDraggablePictureBox(string originalImagePath, string alternateImagePath)
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;

            Image originalImage = Image.FromFile(originalImagePath);
            Image alternateImage = Image.FromFile(alternateImagePath);
            this.Image = originalImage;

            originalPosition = new Point(this.Left, this.Bottom);
            currentPosition = new PointF(this.Left, this.Bottom);

            physicsTimer = new System.Windows.Forms.Timer { Interval = 16 };
            physicsTimer.Tick += UpdatePhysics;
            physicsTimer.Start();

            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    dragStartPoint = e.Location;
                    this.Cursor = Cursors.Hand;
                }
            };

            this.MouseMove += (s, e) =>
            {
                if (isDragging)
                {
                    var parentPanel = this.Parent as Panel;
                    if (parentPanel != null)
                    {
                        Point panelPoint = parentPanel.PointToClient(this.PointToScreen(e.Location));

                        if (panelPoint.X > parentPanel.ClientSize.Width / 2)
                        {
                            this.Image = alternateImage;
                            this.Size = new Size(400, 200);
                            this.SizeMode = PictureBoxSizeMode.Zoom;
                            isInRightHalf = true;
                        }
                        else
                        {
                            this.Image = originalImage;
                            this.Size = new Size(200, 200);
                            this.SizeMode = PictureBoxSizeMode.Zoom;
                            isInRightHalf = false;
                        }

                        int newLeft = this.Left + e.X - dragStartPoint.X;
                        int newTop = this.Top + e.Y - dragStartPoint.Y;

                        newLeft = Math.Max(0, Math.Min(parentPanel.ClientSize.Width - this.Width, newLeft));
                        newTop = Math.Max(0, Math.Min(parentPanel.ClientSize.Height - this.Height, newTop));

                        targetPosition = new PointF(newLeft, newTop);

                        this.BringToFront();
                    }
                }
            };

            this.MouseUp += (s, e) =>
            {
                isDragging = false;
                this.Cursor = Cursors.Default;

                if (!isInRightHalf)
                {
                    targetPosition = new PointF(originalPosition.X, originalPosition.Y);
                }
            };
        }

        private void UpdatePhysics(object sender, EventArgs e)
        {
            float dx = targetPosition.X - currentPosition.X;
            float dy = targetPosition.Y - currentPosition.Y;

            velocity.X += dx * stiffness;
            velocity.Y += dy * stiffness;

            velocity.X *= friction;
            velocity.Y *= friction;

            currentPosition.X += velocity.X;
            currentPosition.Y += velocity.Y;

            if (Math.Abs(velocity.X) < 0.1f && Math.Abs(velocity.Y) < 0.1f)
            {
                velocity.X = 0;
                velocity.Y = 0;

                currentPosition.X = targetPosition.X;
                currentPosition.Y = targetPosition.Y;
            }

            this.Left = (int)Math.Round(currentPosition.X);
            this.Top = (int)Math.Round(currentPosition.Y);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                physicsTimer?.Stop();
                physicsTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
