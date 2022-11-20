using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SocialMediaUserValidator: AbstractValidator<SocialMediaUser>
    {
        public SocialMediaUserValidator()//SocialMediaUser class'ı için Validation kurallarımı yazdım
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.SocialMediaUserAbout).NotEmpty().WithMessage("Hakkında kısmını boş geçemezsiniz");
            RuleFor(x => x.SocialMediaUserTitle).NotEmpty().WithMessage("Ünvan kısmını boş geçemezsiniz");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz");



        }
    }
}
