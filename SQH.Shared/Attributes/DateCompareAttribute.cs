using SQH.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SQH.Shared.Attributes
{
    public class DateCompareAttribute : ValidationAttribute
    {
        private string CampoComparacao { get; set; }
        private TipoComparacao TipoComparacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campoComparacao">Campo de Data para comparação. Se desejar informar a data atual, informar o valor "DataAtual"</param>
        /// <param name="tipoComparacao"></param>
        public DateCompareAttribute(string campoComparacao, TipoComparacao tipoComparacao)
        {
            CampoComparacao = campoComparacao;
            TipoComparacao = tipoComparacao;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime valor = DateTime.MinValue;
            DateTime valorComparacao = DateTime.MinValue;

            if (value != null)
            {
                valor = (DateTime)value;
            }

            if (valor != DateTime.MinValue)
            {
                if (CampoComparacao.Equals("DataAtual"))
                    valorComparacao = DateTime.Now.Date;
                else
                {
                    var propriedadeComparacao = validationContext.ObjectType.GetProperty(CampoComparacao);
                    if (propriedadeComparacao != null &&
                        propriedadeComparacao.GetValue(validationContext.ObjectInstance, null) != null)
                    {
                        valorComparacao = (DateTime)propriedadeComparacao.GetValue(validationContext.ObjectInstance, null);
                    }
                }

                var dateTimeCompare = DateTime.Compare(valor, valorComparacao.Date);

                if (TipoComparacao == TipoComparacao.Menor)
                {
                    if (dateTimeCompare < 0)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult(ErrorMessage);
                }
                else if (TipoComparacao == TipoComparacao.MenorIgual)
                {
                    if (dateTimeCompare < 0 || dateTimeCompare == 0)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult(ErrorMessage);
                }
                else if (TipoComparacao == TipoComparacao.Maior)
                {
                    if (dateTimeCompare > 0)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult(ErrorMessage);
                }
                else if (TipoComparacao == TipoComparacao.MaiorIgual)
                {
                    if (dateTimeCompare > 0 || dateTimeCompare == 0)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult(ErrorMessage);
                }
                else
                {
                    if (dateTimeCompare == 0)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult(ErrorMessage);
                }
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
