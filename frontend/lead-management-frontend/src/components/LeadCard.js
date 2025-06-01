import React from 'react';

export default function LeadCard({ lead, onAccept, onDecline }) {
  const initial = lead.contactFirstName ? lead.contactFirstName.charAt(0).toUpperCase() : '?';
  const date = new Date(lead.dateCreated).toLocaleString();

  return (
    <div className="lead-card">
      <div className="lead-header">
        <div className="lead-avatar">{initial}</div>
        <div>
          <div className="lead-name">{lead.contactFirstName}</div>
          <div className="lead-date">{date}</div>
        </div>
      </div>

      <div className="lead-info">
        <span>📍 {lead.suburb}</span>
        <span>💼 {lead.category}</span>
        <span>Job ID: {lead.id}</span>
      </div>

      {lead.phoneNumber && (
        <div className="lead-contact">
          📞 {lead.phoneNumber} ✉️ {lead.email}
        </div>
      )}

      <div className="lead-description">
        {lead.description}
      </div>

      <div className="lead-footer">
        {lead.status === "Created" && (
          <div className="lead-actions">
            <button onClick={() => onAccept(lead.id)} className="btn btn-accept">Accept</button>
            <button onClick={() => onDecline(lead.id)} className="btn btn-decline">Decline</button>
          </div>
        )}
        <div className="lead-price">
          ${lead.price.toFixed(2)} Lead Invitation
        </div>
      </div>
    </div>
  );
}
