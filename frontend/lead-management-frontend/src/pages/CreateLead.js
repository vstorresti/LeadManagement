import React from 'react';
import api from '../services/api';
import LeadForm from '../components/LeadForm';

export default function CreateLead() {
  const handleCreate = async (lead) => {
    await api.post('/leads', lead);
    alert('Lead created successfully!');
  };

  return (
    <div>
      <h1>Create Lead</h1>
      <LeadForm onSubmit={handleCreate} />
    </div>
  );
}
