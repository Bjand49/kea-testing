describe('template spec', () => {
  it('passes', () => {
    cy.visit('http://localhost:5500');

    //Sign up
    cy.get("#optSignup a").click();

    //Add user details and sign up
    cy.get("#txtEmail").type("test@kea.dk");
    cy.get("#txtPassword").type("pepe");
    cy.get("#txtRepeatPassword").type("pepe");
    cy.get("input[type='submit']").click();
    cy.on('window:alert', (t) => {

    })
    //go to login, and log in (the signup didnt work with the server)
    cy.get("a[href='login.html']").click();
    cy.get("#txtEmail").type("a@a.com");
    cy.get("#txtPassword").type("pepe");
    cy.get("input[type='submit']").click();

    //Find the right elements and add them to the cart

    //Shirt
    cy.get("body >main > section > article").each(article => {
      let header = article.find("header h2").text().trim();
      console.log("header", header);
      if (header == "Mens Casual Premium Slim Fit T-Shirts") {
        article.find(".cart button").click();
        return;
      }
    });

    //SSD
    cy.get("body >main > section > article").each(article => {
      var header = article.find("header h2").text().trim();
      if (header == "SanDisk SSD PLUS 1TB Internal SSD - SATA III 6 Gb/s") {

        cy.wrap(article).within(() => {
          cy.get(".cart input[type='number']")
            .click()
            .type('{upArrow}');
          cy.get(".cart button").click();
        });
        return;
      }
    });
    //checkout cart
    cy.get("#optCart a").click();
    cy.get("#cart form input[type='submit']").click();

    //enter address
    cy.get("#txtDeliveryAddress").type("Guldbergsgade 29N");
    cy.get("#txtDeliveryPostalCode").type("2200");
    cy.get("#txtDeliveryCity").type("Copenhagen");
    cy.get("#chkRepeat").click();
    cy.get("#txtCreditCardName").type("Pernille L. Hansen");
    cy.get("#txtExpiryDate")
      .click()
      .type("2027-12");
    cy.get(".submit input[value='Place Purchase'").click();
    cy.get("#txtCVV").type("666");
    cy.get("#checkout form div.submit input[type='submit']").click();

    //checkout cart
    cy.get("#optCart a").click();
    cy.get("#alert p").should('have.text', 'The cart is empty. Please add some products to the cart.')
  })
})