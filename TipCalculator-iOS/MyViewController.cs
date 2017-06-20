using System;
using UIKit;
using CoreGraphics;

namespace TipCalculatoriOS {
    public class MyViewController : UIViewController {
        
        public MyViewController() {
            
        }

        // Overriding the ViewDidLoad and calling the base implementation
        public override void ViewDidLoad() {
            base.ViewDidLoad();

            // Set the background to yellow
            View.BackgroundColor = UIColor.Yellow;

            // 20 pts from the left and right
            // 28 pts from the top
            // 35 pts high
            CGRect rect = new CGRect(20, 28, View.Bounds.Width - 40, 35);

            // TextField properties
            UITextField totalAmount = new UITextField(rect) {
                KeyboardType = UIKeyboardType.DecimalPad,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Placeholder = "Enter Total Amount",
            };

            // Create the calculate button

            UIButton calcButton = new UIButton(UIButtonType.Custom) {
                Frame = new CGRect(20, 71, View.Bounds.Width - 40, 45),
                BackgroundColor = UIColor.FromRGB(0, 0.5f, 0),
            };

            calcButton.SetTitle("Calculate", UIControlState.Normal);

            // Creates the label
            UILabel resultLabel = new UILabel(new CGRect(0, 124, View.Bounds.Width, 40)) {
                TextColor = UIColor.Blue,
                TextAlignment = UITextAlignment.Center,
                Font = UIFont.SystemFontOfSize(24),
                Text = "Tip is $0.00",
            };

            // Add the subviews to the root view
            View.AddSubviews(totalAmount, calcButton, resultLabel);

            calcButton.TouchUpInside += (sender, e) => {

                // Calculate the tip and display it
                double userInput = Double.Parse(totalAmount.Text);
                resultLabel.Text = string.Format("Tip is {0:C}", userInput * 0.2);

                // Dismiss the keyboard when the button is pressed
                totalAmount.ResignFirstResponder();
            };

        }

    }
}
