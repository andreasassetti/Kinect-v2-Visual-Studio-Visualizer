namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    partial class Kinect2DFrameVisualizerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainerFrame = new System.Windows.Forms.SplitContainer();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.kinect2DFrame1 = new MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Kinect2DFrame();
            this.propertyGridFrame = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFrame)).BeginInit();
            this.splitContainerFrame.Panel1.SuspendLayout();
            this.splitContainerFrame.Panel2.SuspendLayout();
            this.splitContainerFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preview:";
            // 
            // splitContainerFrame
            // 
            this.splitContainerFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerFrame.Location = new System.Drawing.Point(15, 29);
            this.splitContainerFrame.Name = "splitContainerFrame";
            // 
            // splitContainerFrame.Panel1
            // 
            this.splitContainerFrame.Panel1.Controls.Add(this.elementHost1);
            // 
            // splitContainerFrame.Panel2
            // 
            this.splitContainerFrame.Panel2.Controls.Add(this.propertyGridFrame);
            this.splitContainerFrame.Size = new System.Drawing.Size(665, 322);
            this.splitContainerFrame.SplitterDistance = 455;
            this.splitContainerFrame.TabIndex = 1;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(455, 322);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.kinect2DFrame1;
            // 
            // propertyGridFrame
            // 
            this.propertyGridFrame.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propertyGridFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridFrame.Location = new System.Drawing.Point(0, 0);
            this.propertyGridFrame.Name = "propertyGridFrame";
            this.propertyGridFrame.Size = new System.Drawing.Size(206, 322);
            this.propertyGridFrame.TabIndex = 0;
            // 
            // Kinect2DFrameVisualizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 363);
            this.Controls.Add(this.splitContainerFrame);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Kinect2DFrameVisualizerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kinect 2D Frame visualizer";
            this.splitContainerFrame.Panel1.ResumeLayout(false);
            this.splitContainerFrame.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFrame)).EndInit();
            this.splitContainerFrame.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainerFrame;
        private System.Windows.Forms.PropertyGrid propertyGridFrame;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Kinect2DFrame kinect2DFrame1;
    }
}