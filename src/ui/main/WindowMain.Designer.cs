namespace FileModifier;

partial class WindowMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.load = new System.Windows.Forms.Button();
        this.write = new System.Windows.Forms.Button();
        this.append = new System.Windows.Forms.Button();
        this.loadInput = new System.Windows.Forms.TextBox();
        this.appendInput = new System.Windows.Forms.TextBox();
        this.SuspendLayout();

        this.load.Text = "Load";
        this.load.Location = new System.Drawing.Point(45, 60);
        this.load.Height = 25;
        this.load.Width = 80;
        this.load.Click += new System.EventHandler(EventHandler.LoadFile);

        this.write.Text = "Write";
        this.write.Location = new System.Drawing.Point(45, 140);
        this.write.TabIndex = 1;
        this.write.Height = 25;
        this.write.Width = 80;
        this.write.Name = "write_button";
        this.write.Click += new System.EventHandler(EventHandler.ModifyFile);

        this.append.Text = "Append";
        this.append.Location = new System.Drawing.Point(45, 220);
        this.append.TabIndex = 2;
        this.append.Height = 25;
        this.append.Width = 80;
        this.append.Name = "append_button";
        this.append.Click += new System.EventHandler(EventHandler.ModifyFile);

        this.loadInput.Location = new System.Drawing.Point(200, 60);
        this.loadInput.Size = new System.Drawing.Size(200, 25);
        this.loadInput.Name = "pathFile";
        this.loadInput.TabIndex = 3;

        this.appendInput.Location = new System.Drawing.Point(200, 220);
        this.appendInput.Size = new System.Drawing.Size(200, 25);
        this.appendInput.Name = "appendText";
        this.appendInput.TabIndex = 4;

        this.Size = new System.Drawing.Size(480, 400);
        this.Text = "FileModifier - Main";
        this.Icon = new Icon("./src/img/icon.ico");
        this.StartPosition = FormStartPosition.Manual;
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.CenterToScreen();
        this.Controls.Add(this.load);
        this.Controls.Add(this.write);
        this.Controls.Add(this.append);
        this.Controls.Add(this.loadInput);
        this.Controls.Add(this.appendInput);
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button load;
    private System.Windows.Forms.Button write;
    private System.Windows.Forms.Button append;
    private System.Windows.Forms.TextBox loadInput;
    private System.Windows.Forms.TextBox appendInput;
}
