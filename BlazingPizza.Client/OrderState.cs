using System;
using System.Collections.Generic;

namespace BlazingPizza.Client
{
    /* Move the configuringPizza, showingConfigureDialog and order fields 
     * to be properties on the OrderState class. 
     * Make them private set so they can only be manipulated via methods on OrderState
     */
    public class OrderState
    {
        public bool ShowingConfigureDialog { get; private set; }

        public Pizza ConfiguringPizza { get; private set; }

        public Order Order { get; private set; } = new Order();

        public void ShowConfigurePizzaDialog(PizzaSpecial special)
        {
            ConfiguringPizza = new Pizza()
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Toppings = new List<PizzaTopping>(),
            };

            ShowingConfigureDialog = true;
        }

        // This event that hides the dialog and empties the configuring pizza
        public void CancelConfigurePizzaDialog()
        {
            ConfiguringPizza = null;

            ShowingConfigureDialog = false;
        }

        // OnConfirm event that adds the configured pizza to the order and empties the configuring pizza
        public void ConfirmConfigurePizzaDialog()
        {
            Order.Pizzas.Add(ConfiguringPizza);
            ConfiguringPizza = null;

            ShowingConfigureDialog = false;
        }

        public void ResetOrder()
        {
            Order = new Order();
        }

        // component for removing a configured pizza from the order
        public void RemoveConfiguredPizza(Pizza pizza)
        {
            Order.Pizzas.Remove(pizza);
        }

        public void ReplaceOrder(Order order)
        {
            Order = order;
        }
    }
}
