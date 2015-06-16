using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AM_QMQ.Helpers
{
    public static class Helper
    {
        public static IHtmlString Botao(string valor, string tipo)
        {
            var tag = String.Format("<input type='submit' value={0} class='btn btn-{1}' />", valor, tipo);
            return new HtmlString(tag);
        }

        public static IHtmlString Mensagem(string mensagem, string tipo)
        {
            var tag = "";
            if (mensagem != null)
            {
                tag = String.Format("<div class='alert alert-{1}'>{0}</div>", mensagem, tipo);
            }
            return new HtmlString(tag);
        }
    }
}