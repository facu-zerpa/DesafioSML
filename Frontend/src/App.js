import "./App.css";

import React, { useState, useEffect } from "react";

import Axios from "axios";
import Swal from "sweetalert2";

import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import Table from "react-bootstrap/Table";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";

const App = () => {
  const [listCustomers, setListCustomers] = useState([]);
  const [listInvoicesItems, setListInvoicesItems] = useState([]);
  const [inputInvoiceItem, setInputInvoicItem] = useState("");
  const [selectedCustomer, setSelectedCustomer] = useState(0);
  const [messageCustomer, setMessageCustomer] = useState("");
  const [messageItem, setMessageItem] = useState("");

  useEffect(() => {
    if (listCustomers.length === 0) {
      getCustomers();
    }
  }, [listCustomers]);

  const getCustomers = async () => {
    try {
      const response = await Axios({
        url: "https://localhost:7070/Customer",
      });
      setListCustomers(response.data);
    } catch (error) {
      console.log(error);
    }
  };

  const sendInvoice = async () => {
    const obj = {
      date: Date.now,
      customerId: parseInt(selectedCustomer),
      codes: listInvoicesItems,
    };
    console.log(obj);
    try {
      const response = await Axios.post("https://localhost:7070/Invoice", obj);
      return response;
    } catch (error) {
      console.log(error);
    }
  };

  const addInvoiceitem = () => {
    const item = inputInvoiceItem.toUpperCase();
    if (listInvoicesItems.includes(item)) {
      setMessageItem("El producto ya ha sido agregado.");
      return;
    }

    setMessageItem("");

    const list = [...listInvoicesItems, item];
    setListInvoicesItems(list);
    setInputInvoicItem("");
  };

  const deleteItem = (index) => {
    setListInvoicesItems((items) =>
      listInvoicesItems.filter((it, i) => i !== index)
    );
  };

  const createInvoice = () => {
    if (selectedCustomer === 0) {
      setMessageCustomer("Es obligatorio seleccinar un cliente.");
      return;
    }

    setMessageCustomer("");

    sendInvoice()
      .then((response) => {
        if (response.status !== 200) {
          Swal.fire({  
            title: 'Error',  
            text: 'No se pudo cargar la factura.',
            icon: 'error'
          }); 
          return;
        }
        Swal.fire({  
          title: 'Exito',  
          text: 'Se cargo correctamente la factura.',
          icon: 'success'
        });
        setSelectedCustomer(0);
        setListInvoicesItems([]);
      })
      .catch((error) => error);
  };

  return (
    <Container>
      <Row>
        <Col sm={4}>
          <div className="mb-4">
            <h4>Clientes</h4>
            <Form.Select
              onChange={(e) => setSelectedCustomer(e.target.value)}
              value={selectedCustomer}
            >
              <option key="0" value="0" disabled>
                -- Seleccionar --
              </option>
              {listCustomers.map((customer) => (
                <option key={customer.customerId} value={customer.customerId}>
                  {`${customer.firstName} ${customer.lastName}`}
                </option>
              ))}
            </Form.Select>
            {messageCustomer !== "" && (
              <Form.Text id="customerHelp" className="text-danger">
                {messageCustomer}
              </Form.Text>
            )}
          </div>
          <div>
            <h3>Agregar Producto</h3>
            <div className="mb-2">
              <Form.Label htmlFor="product">Producto</Form.Label>
              <Form.Control
                type="text"
                id="product"
                value={inputInvoiceItem}
                onChange={(e) => setInputInvoicItem(e.target.value)}
              />
              {messageItem !== "" && (
                <Form.Text id="customerHelp" className="text-danger">
                  {messageItem}
                </Form.Text>
              )}
            </div>
            <Button variant="primary" onClick={() => addInvoiceitem()}>
              Agregar
            </Button>
          </div>
        </Col>
        <Col sm={8} className="text-center">
          <h4>Lista Productos</h4>

          {listInvoicesItems.length === 0 ? (
            <div className="h-100 w-100 d-flex justify-content-center align-items-center ">
              <h4>No hay items</h4>
            </div>
          ) : (
            <>
              <div className="d-flex justify-content-center">
                <Table className="w-75">
                  <thead>
                    <tr>
                      <th className="text-center">Codigo</th>
                      <th className="text-center">Accion</th>
                    </tr>
                  </thead>
                  <tbody>
                    {listInvoicesItems.map((item, index) => (
                      <tr>
                        <td className="text-center">{item}</td>
                        <td className="text-center">
                          <Button
                            variant="danger"
                            size="sm"
                            onClick={() => deleteItem(index)}
                          >
                            Eliminar
                          </Button>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </Table>
              </div>
              <Button variant="primary" onClick={() => createInvoice()}>
                Crear Factura
              </Button>
            </>
          )}
        </Col>
      </Row>
    </Container>
  );
};

export default App;
