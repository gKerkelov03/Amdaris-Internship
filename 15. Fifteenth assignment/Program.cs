

IOrderObserver customer1 = new Customer("Gosho");
IOrderObserver customer2 = new Customer("Pesho");
IOrderObserver staff1 = new StaffMember("Stamo");
IOrderObserver staff2 = new StaffMember("Vasko");

var id = Guid.NewGuid().ToString();
var order = new Order(id, [staff1, staff2]);

order.Subscribe(customer1);
order.Subscribe(customer2);

order.UpdateStatus(OrderStatus.Preparing);

order.Unsubscribe(customer1);
order.Unsubscribe(customer2);

order.UpdateStatus(OrderStatus.ReadyForShipping);
