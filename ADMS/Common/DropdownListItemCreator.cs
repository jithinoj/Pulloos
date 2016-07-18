using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADMS.Common
{
    public static class DropdownListItemCreator
    {

        public static SelectList GetSelectedListItems<TEntity>(IEnumerable<TEntity> entities, string value, string text)
            where TEntity: class
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var type = typeof(TEntity);

            var valueProperty = type.GetProperty(value);
            var textProperty = type.GetProperty(text);

            foreach (TEntity item in entities)
            {

                string itemValue = valueProperty.GetValue(item, new object[] { }).ToString();
                string itemText = textProperty.GetValue(item, new object[] { }).ToString();

                items.Add(new SelectListItem
                                        {
                                            Value = itemValue,
                                            Text = itemText
                                        });
            }

            return new SelectList(items);
        }

    }
}