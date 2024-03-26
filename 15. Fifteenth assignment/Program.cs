var customer1 = new Customer("Gosho");
var customer2 = new Customer("Pesho");
var staff1 = new StaffMember("Stamo");
var staff2 = new StaffMember("Vasko");

var id = Guid.NewGuid().ToString();
var order = new Order(id, [staff1, staff2]);

order.Subscribe(customer1);
order.Subscribe(customer2);

order.UpdateStatus(OrderStatus.Preparing);

order.Unsubscribe(customer1);
order.Unsubscribe(customer2);

order.UpdateStatus(OrderStatus.ReadyForShipping);
