import React, { useState } from 'react';

export default function LeadForm({ onSubmit }) {
  const [lead, setLead] = useState({
    contactFirstName: '',
    contactFullName: '',
    phoneNumber: '',
    email: '',
    suburb: '',
    category: '',
    description: '',
    price: ''
  });

  const handleChange = (e) => {
    setLead({ ...lead, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit({ 
      ...lead, 
      price: parseFloat(lead.price)
    });
    setLead({
      contactFirstName: '',
      contactFullName: '',
      phoneNumber: '',
      email: '',
      suburb: '',
      category: '',
      description: '',
      price: ''
    });
  };

  return (
    <form onSubmit={handleSubmit} className="lead-card">
      <h2>Add New Lead</h2>

      <input
        type="text"
        name="contactFirstName"
        placeholder="Contact First Name"
        value={lead.contactFirstName}
        onChange={handleChange}
        required
      />

      <input
        type="text"
        name="contactFullName"
        placeholder="Contact Full Name"
        value={lead.contactFullName}
        onChange={handleChange}
        required
      />

      <input
        type="text"
        name="phoneNumber"
        placeholder="Phone Number"
        value={lead.phoneNumber}
        onChange={handleChange}
        required
      />

      <input
        type="email"
        name="email"
        placeholder="Email"
        value={lead.email}
        onChange={handleChange}
        required
      />

      <input
        type="text"
        name="suburb"
        placeholder="Suburb"
        value={lead.suburb}
        onChange={handleChange}
        required
      />

      <input
        type="text"
        name="category"
        placeholder="Category"
        value={lead.category}
        onChange={handleChange}
        required
      />

      <textarea
        name="description"
        placeholder="Description"
        value={lead.description}
        onChange={handleChange}
        required
      />

      <input
        type="number"
        name="price"
        placeholder="Price"
        value={lead.price}
        onChange={handleChange}
        required
        step="0.01"
      />

      <button type="submit" className="btn btn-accept">Add Lead</button>
    </form>
  );
}
