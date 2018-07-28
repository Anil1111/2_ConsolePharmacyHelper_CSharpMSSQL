ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Prescriptions FOREIGN KEY (PrescriptionID)
REFERENCES Prescriptions (ID);
ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Medicines FOREIGN KEY (MedicineID)
REFERENCES Medicines (ID);

Select * from Medicines as M 
JOIN Orders as O  ON M.ID = O.MedicineID
JOIN Prescriptions as P ON M.ID = P.ID

INSERT INTO Medicines (Name) 
VALUES ('Rutinoscorbin');

Select * From Medicines

DELETE FROM Medicines WHERE PRICE IS NULL

UPDATE Medicines SET Name = 'Rutinoscorbin', Manufacturer = 'PolFarma'
			                     WHERE (ID = 2);


