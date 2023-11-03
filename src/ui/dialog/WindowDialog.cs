namespace FileModifier;

public class WindowDialog
{
    public static Form showDialog(string name, string iconPath, string textlabel)
    {
        Form dialogWindow = new()
        {
            Text = name,
            Icon = new Icon(iconPath),
            Size = new Size(380, 200),
            // MaximizeBox = false,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            StartPosition = FormStartPosition.CenterParent,
        };
        Label labelDialog = new()
        {
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            Text = textlabel
        };


        dialogWindow.Resize += (object sender, EventArgs args) =>
        {
            Form actualForm = (Form)sender;

            if (actualForm.WindowState == FormWindowState.Maximized)
            {
                dialogWindow.Padding = new Padding(10);
                labelDialog.TextAlign = ContentAlignment.TopLeft;
            }
            else if(actualForm.WindowState == FormWindowState.Normal)
            {
                dialogWindow.Padding = new Padding(10);
                labelDialog.TextAlign = ContentAlignment.MiddleCenter;
            }
        };

        dialogWindow.Controls.Add(labelDialog);
        dialogWindow.ShowDialog();

        return dialogWindow;
    }
}