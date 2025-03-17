#include"System.h"
using std::cout;
using std::endl;
using std::cin;
void printline(string s, bool l = true) {
    cout << s << (l == true ? '\n' : '\t');
}
char c = 'n';
int b = -1;
bool check = false;
System::System(int s1,int s2):carSize(0), customerSize(0){
    setCarSize(s1);
    setCustomerSize(s2);
    car = new Car[carSize];
    customer = new Customer*[customerSize];
    for (int i = 0; i < customerSize; i++) {
        customer[i] = nullptr;
}
}
void System::setCarSize(int s) {
    if (s < 0)
        cout << "Invalid input..please try again!";
    else
    carSize = s;
}
void System::setCustomerSize(int s) {
    if(s<0)
        cout << "Invalid input..please try again!";
    else
    customerSize = s;
}
int System::Search_car(int id){
    for (int i = 0; i < carSize; i++) {
        if (car[i].getId() == id) {
            return i;
        }
    }
    return -1;
}
int System::search_customer(int n){
    for (int i = 0; i < customerSize; i++) {
        if (customer[i]->getId() == n) {
            return i;
        }
    }
    return -1;
}
void System::addCar(){
    char c = 'y';
    do {
        if (carCount ==carSize) {
            cout << "\nYou exceeded the utmost number of cars!you can't add more ";
            return;
        }
        else {
            cin >> car[carCount++];
            cout << "Do you want to add another car(y/n): ";
            cin >> c;
        }
    }
     while (c != 'n');
}      
void System::addCustomer() {
    int n;
    c = 'n';
    do {
        if (customerCount == customerSize) {
            cout << "\nYou exceeded the utmost number of customers. You can't add more." << endl;
            return;
        }
        cout << "What kind of customer do you want to add? (1-person, 2-company): ";
        cin >> n;
        switch (n) {
        case 1:
            customer[customerCount] = new Person;
            break;
        case 2:
            customer[customerCount] = new Company;
            break;
        default:
            cout << "Invalid choice. Please try again." << endl;
            continue;
        }
        cin >> *(customer[customerCount]);
        customerCount++;
        cout << "Do you want to add another customer? (y/n): ";
        cin >> c;
    } while (c != 'n');
}

void System::rentCar() {
    c = 'n';
    printline("##Rent car system");
    do {
        string s;
        cout << "1-renting a car\n2-returning to main menu\n\tEnter choice:  ";
        cin >> b;
        if (b == 1) {
            reservation.readCarId();
            int carIndex = Search_car(reservation.getCarId());
            if (carIndex == -1) {
                cout << "\nSorry!! Car specified isn't found";
                stat = notCompleted;
                return;
            }
            reservation.readCustomerName();
            int customerIndex = search_customer(reservation.getCustomerId());
            if (customerIndex == -1) {
                cout << "\nSorry!! Customer specified isn't found";
                stat = notCompleted;
                return;
            }
            else {
                cin >> reservation;
                if (car[carIndex].checkAvailability(reservation.getStartDate(), reservation.getEndDate())) {
                    reservation.readInvoice();
                    if (car[carIndex].checkSize() && customer[customerIndex]->checkSize()) {
                        car[carIndex].addReservation(reservation);
                        customer[customerIndex]->addReservation(reservation);
                        cout << "\nReservation Completed" << endl;
                        stat = completed;
                    }
                    else {
                        cout << "\nfailed to rent";
                        stat = still;
                    }
                }
                else {
                    cout << "\nYou can't rent the car in this period";
                    stat = still;
                }
            }
            reservation.setStatue(stat);
        }
        else if (b == 2) {
            cout << "\nReturning to main menu...";
            return;
        }
        else
            printline("Invalid choice...Try again!");
        cout << "\nDo you want to continue in the menu?(y/n)";
        cin >> c;
    } while (c == 'y');
}
void System::returnCar() {
    Date d;
    c = 'n';
    printline("##Return car system");

    do {
        cout << "\n1-Returning a car\n2-Returning to main menu\n\tEnter choice: ";
        cin >> b;

        switch (b) {
        case 1: {
            int id;
            cout << "\nEnter the ID of the car you want to return: ";
            cin >> id;

            int index = Search_car(id);
            if (index == -1) {
                cout << "\nSorry! The specified car is not found." << endl;
                stat = still;
            }
            else {
                for (int i = index; i < carCount - 1; i++) {
                    car[i] = car[i + 1];
                }
                carCount--;

                stat = canceled;
                cout << "\nCar returned successfully." << endl;
            }

            reservation.setStatue(stat);
            break;
        }

        case 2:
            cout << "\nReturning to the main menu..." << endl;
            return;

        default:
            cout << "\nInvalid choice. Please try again!" << endl;
        }

        cout << "\nDo you want to continue in the menu? (y/n): ";
        cin >> c;
    } while (c == 'y');
}

void System::viewAllAvailableCars() {
    check = false;
    c = 'n';
    printline("##Viewing available cars");
    do {
       std:: cout << "\n1-View available cars\n2-Return to main menu\n\tEnter choice: ";
        std::cin >> b;
        if (b == 1) {
            Date start_date, end_date;
            cout << "Enter rental start date: " << endl;
            cin >> start_date;
            cout << "Enter rental end date: " << endl;
            cin >> end_date;
            for (int index = 0; index < carCount; index++)
            {
                if (car[index].checkAvailability(start_date, end_date)) {
                    cout << "\nCar details:\n" << car[index];
                    check = true;
                    break;
                }
            }if (check == false)
                cout << "\nNo available cars found...";
        }
        else if (b == 2) {
            cout << "\nReturning to main menu...";
            return;
        }
        else cout << "\nInvalid choice...Try again!";
        cout << "\nContinue in the menu?(y/n)";
        cin >> c;
    } while (c == 'y');
}
    void System::viewCustomerRentalHistory(){
        printline("##Viewing Rental history");
        cout << "\n1-View Rental history\n2-Return to main menu\n\tEnter choice: ";
        cin >> b;
        if (b == 1) {
            int id;
            cout << "Enter Customers id: " << endl;
            cin >> id;
            cout << endl;
            int index = search_customer(id);
            if (index == -1)
                cout << "Customer not found" << endl;
            else
                customer[index]->printData(cout) << endl;
        }
        else if (b == 2) {
            cout << "\nReturning to main menu...";
            return;
        }
        else cout << "\nInvalid choice...Try again!";
    }
    void System::generateReports() {
        printline("##Generate reports");
        cout << "\n1-Report car\n2-Customer history\n3-Return to main menu\n\tEnter choice: ";
        cin >> b;
        switch (b) {
        case 1:
            if (customerCount != 0) {
                cout << setw(50) << "Customers rental history:" << endl;
                for (int i = 0; i < customerCount; i++)
                {
                    cout << "---Customer number" << i + 1 << " details: " << endl;
                    customer[i]->printData(cout) << endl;
                }
            }
            break;
        case 2:
            if (carCount != 0) {
                cout << setw(50) << "Cars rental history: " << endl;
                for (int i = 0; i < carCount; i++)
                {
                    cout << "---Car number " << i + 1 << " details: " << endl;
                    cout << car[i] << endl;
                }
            }
            break;
        case 3:
            cout << "\nReturning to main menu...";
            return;
        default:
            cout << "\nInvalid choice...Try again ";
        }
    }
    
    System::~System(){
        delete[]car;
        for (int i = 0; i < customerCount; i++)
            delete customer[i];
        delete[]customer;
    }