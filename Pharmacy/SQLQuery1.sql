ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Prescriptions FOREIGN KEY (PrescriptionID)
REFERENCES Prescriptions (ID);
ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Medicines FOREIGN KEY (MedicineID)
REFERENCES Medicines (ID);