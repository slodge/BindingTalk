using System;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class YesNoQuestion
    {
        public Action YesAction { get; set; }
        public Action NoAction { get; set; }
        public string QuestionText { get; set; }

        public YesNoQuestion()
        {
            YesAction = () => { };
            NoAction = () => { };
        }
    }

    public class QuestionViewModel
        : MvxViewModel
    {
        private MvxInteraction<YesNoQuestion> _confirm = new MvxInteraction<YesNoQuestion>();
        public IMvxInteraction<YesNoQuestion> Confirm
        {
            get { return _confirm; }
        }

        public IMvxCommand GoCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        var question = new YesNoQuestion()
                            {
                                QuestionText = "Close me now?",
                                YesAction = () => Close(this),
                            };
                        _confirm.Raise(question);
                    });
            }
        }
    }
}