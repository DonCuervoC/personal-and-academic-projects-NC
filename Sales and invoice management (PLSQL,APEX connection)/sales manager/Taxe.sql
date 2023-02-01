

CREATE OR REPLACE FUNCTION COMPAGNIE.tax_nacc(total IN NUMBER)
RETURN NUMBER IS
	 totApresTax NUMBER;
BEGIN
		totApresTax:= total+((total*15)/100);
		RETURN (totApresTax);
END;
/
