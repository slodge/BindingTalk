using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class CustomControlViewModel
        : MvxViewModel
    {
        public enum Shape
        {
            Circle,
            Square,
            Triangle
        }

        private List<Shape> _allShapes = new List<Shape>()
            {
                Shape.Circle,
                Shape.Square,
                Shape.Triangle
            };
        public List<Shape> AllShapes 
        {   
            get { return _allShapes; }
            set { _allShapes = value; RaisePropertyChanged(() => AllShapes); }
        }

        private Shape _theShape;
        public Shape TheShape 
        {   
            get { return _theShape; }
            set { _theShape = value; RaisePropertyChanged(() => TheShape); }
        }
    }
}