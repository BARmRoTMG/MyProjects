set quoted_identifier on
GO
set identity_insert "Customers" on
go
ALTER TABLE "Customers" NOCHECK CONSTRAINT ALL
go

INSERT "Customers" VALUES(1, 'Bar', 'Mashiach', 0, 'Derech Hayam 24', 'Ganei Tikva', 'Israel', '55555', 'Israel', '0547443655')

go
set identity_insert "Customers" off
go
ALTER TABLE "Categories" CHECK CONSTRAINT ALL
go